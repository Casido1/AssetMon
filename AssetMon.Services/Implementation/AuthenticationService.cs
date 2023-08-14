using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using LoggerService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AssetMon.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(ILoggerManager logger, UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<IdentityResult> RegisterUser(UserForRegisterationDTO userForRegisterationDTO)
        {
            var user = _mapper.Map<AppUser>(userForRegisterationDTO);

            var result = await _userManager.CreateAsync(user, userForRegisterationDTO.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegisterationDTO.Roles);
            }

            return result;
        }
    }
}
