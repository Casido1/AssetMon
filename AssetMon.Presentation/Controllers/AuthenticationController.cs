using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
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

        [HttpPost]
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
    }
}
