﻿using AssetMon.Shared.DTOs;
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
        Task<IdentityResult> ConfirmPasswordResetAsync(string userId, string token, string newPassword);
        Task<bool> ReassignRole(string userId, IEnumerable<string> roles);
        Task<bool> RequestEmailVerificationAsync(string userId);
        Task<IdentityResult> ConfirmEmail(string userId, string token);
    }
}
