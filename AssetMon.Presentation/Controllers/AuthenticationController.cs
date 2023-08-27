using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager) 
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterationDTO userForRegisterationDTO)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegisterationDTO);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors) 
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            if (!await _serviceManager.AuthenticationService.LoginUser(userLoginDTO))
                return Unauthorized();

            var tokenDTO = await _serviceManager.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDTO);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDTO)
        {
            var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDTO);

            return Ok(tokenDtoToReturn);
        }

        [HttpPost("reset-password/request")]
        public async Task<IActionResult> RequestPasswordReset(string email)
        {
            var result = await _serviceManager.AuthenticationService.RequestPasswordReset(email);
            if (result) return Ok();

            return NotFound("Email does not exist");
        }

        [HttpPost("reset-password/confirm")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ConfirmPasswordReset(PassWordResetDTO passWordResetDTO)
        {
            var result = await _serviceManager.AuthenticationService.ConfirmPasswordResetAsync(passWordResetDTO.UserId, passWordResetDTO.Token, passWordResetDTO.NewPassword);
            
            if(result.Succeeded) return Ok("Password reset confirmed successfully");

            return BadRequest(result.Errors.Select(error => error.Description));    
        }

        [HttpPost("reassignroles")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ReassignRoles([FromBody] RoleReassignmentDTO roleReassignmentDTO)
        {
            var result = await _serviceManager.AuthenticationService.ReassignRole(roleReassignmentDTO.UserId, roleReassignmentDTO.Roles);

            if (result) return Ok();
            return NotFound("Role does not exist");
        }

        [HttpPost("verify-email/request")]
        [Authorize]
        public async Task<IActionResult> RequestEmailVerification()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return BadRequest("UserId not found");

            var success = await _serviceManager.AuthenticationService.RequestEmailVerificationAsync(userId);
            if(success) return Ok();

            return NotFound("User not found");
        }

        [HttpPost("verify-email/confirm")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(EmailVerificationDTO emailVerificationDTO)
        {
            var result = await _serviceManager.AuthenticationService.ConfirmEmail(emailVerificationDTO.UserId, emailVerificationDTO.Token);

            if (result.Succeeded) return Ok("Email confirmed successfully");

            return BadRequest(result.Errors.Select(error => error.Description));
        }
    }
}
