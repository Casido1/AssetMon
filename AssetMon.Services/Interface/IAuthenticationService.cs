using AssetMon.Shared.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AssetMon.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterationDTO userForRegisterationDTO);
        Task<bool> LoginUser(UserLoginDTO userLoginDTO);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDTO);
        Task<bool> RequestPasswordReset(string email);
    }
}
