using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("requestpasswordrequest")]
        public async Task<IActionResult> RequestPasswordReset(string email)
        {
            var result = await _serviceManager.AuthenticationService.RequestPasswordReset(email);
            if (result) return Ok();

            return NotFound("Email does not exist");
        }

        [HttpPost("confirmpasswordreset")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ConfirmPasswordReset(PassWordResetDTO passWordResetDTO)
        {
            var result = await _serviceManager.AuthenticationService.ConfirmPasswordResetAsync(passWordResetDTO.UserId, passWordResetDTO.Token, passWordResetDTO.NewPassword);
            
            if(result.Succeeded) return Ok("Password reset confirmed successfully");

            return BadRequest(result.Errors.Select(error => error.Description));    
        }

        [HttpPost("reassignroles")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ReassignRoles([FromBody] RoleReassignmentDTO roleReassignmentDTO)
        {
            var result = await _serviceManager.AuthenticationService.ReassignRole(roleReassignmentDTO.UserId, roleReassignmentDTO.Roles);

            if (result) return Ok();
            return NotFound("Role does not exist");
        }
    }
}
