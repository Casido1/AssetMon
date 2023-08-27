using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.ConfigurationModels;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using LoggerService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AssetMon.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private AppUser _user;
        private readonly JwtConfiguration _jwtConfiguration;

        public AuthenticationService(ILoggerManager logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IRepositoryManager repositoryManager,
            IEmailService emailService, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _configuration = configuration;
            _jwtConfiguration = new JwtConfiguration();
            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
        }

        public async Task<bool> LoginUser(UserLoginDTO userLoginDTO)
        {
            _user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (_user == null) return false;
            var result = await _userManager.CheckPasswordAsync(_user, userLoginDTO.Password);

            if (!result)
                _logger.LogWarn($"{nameof(LoginUser)}: Authentication failed. Wrong user name or password.");

            return result;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterationDTO userForRegisterationDTO)
        {
            var user = _mapper.Map<AppUser>(userForRegisterationDTO);

            var result = await _userManager.CreateAsync(user, userForRegisterationDTO.Password);

            if (result.Succeeded)
            {
                foreach(var role in userForRegisterationDTO.Roles)
                {
                    if(!string.Equals(role, "Administrator", StringComparison.OrdinalIgnoreCase))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }

                //Create UserProfile
                var userProfile = _mapper.Map<UserProfile>(userForRegisterationDTO);
                userProfile.AppUserId = user.Id;

                await _repositoryManager.User.CreateUserProfileAsync(userProfile);
                await _repositoryManager.SaveAsync();
            }

            return result;
        }

        #region Token

        public async Task<TokenDTO> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;
            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDTO { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, _user.Id),
                new  Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
           securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        public async Task<TokenDTO> RefreshToken(TokenDTO tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();
            _user = user;

            return await CreateToken(populateExp: false);
        }

        #endregion

        public async Task<bool> RequestPasswordReset(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            if(_user == null) return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(_user);

            var model = new EmailOptions 
            { 
                PlaceHolder = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "{{Token}}", $"{token}" )
                } 
            };
            await _emailService.SendPasswordResetEmailAsync(model);

            return true;
        }

        public async Task<IdentityResult> ConfirmPasswordResetAsync(string userId, string token, string newPassword)
        {
            _user = await _userManager.FindByIdAsync(userId);
            if (_user == null) return IdentityResult.Failed(new IdentityError { Description = "user not found" });

            var result = await _userManager.ResetPasswordAsync(_user, token, newPassword);

            return result;
        }

        public async Task<bool> ReassignRole(string userId, IEnumerable<string> roles)
        {
            _user = await _userManager.FindByIdAsync(userId);
            if (_user == null) throw new UserProfileNotFoundException(userId);
            // Remove existing roles
            var existingRoles = await _userManager.GetRolesAsync(_user);
            await _userManager.RemoveFromRolesAsync(_user, existingRoles);

            // Assign new roles
            foreach (var role in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (roleExists)
                {
                    await _userManager.AddToRoleAsync(_user, role);
                }
            }

            return true;
        }

        public async Task<bool> RequestEmailVerificationAsync(string userId)
        {
            _user = await _userManager.FindByIdAsync(userId);
            if(_user == null)
            {
                return false;
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(_user);

            //var callbackUrl = ""; // Create a URL to your email verification endpoint

            var model = new EmailOptions
            {
                PlaceHolder = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "{{Token}}", $"{token}" )
                }
            };
            
            await _emailService.SendEmailConfirmationMailAsync(model);

            return true;
        }

        public async Task<IdentityResult> ConfirmEmail(string userId, string token)
        {
            _user = await _userManager.FindByIdAsync(userId);
            if (_user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "user not found" });
            }

            var result = await _userManager.ConfirmEmailAsync(_user, token);

            return result;
        }
    }
}
