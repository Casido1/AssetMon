using AssetMon.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterationDTO userForRegisterationDTO);
        Task<bool> LoginUser(UserLoginDTO userLoginDTO);
        Task<string> CreateToken();
    }
}
