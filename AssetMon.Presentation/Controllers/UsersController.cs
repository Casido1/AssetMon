using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Users/{userId}")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("userprofile")]
        public async Task<IActionResult> GetUserProfileById(string userId)
        {
            var result = await _serviceManager.UserService.GetUserProfileByIdAsync(userId, trackChanges: false);

            return Ok(result);
        }

        [HttpPut("userprofile")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUserProfile(string userId, [FromBody] UserProfileDTO userProfileDTO)
        {
            await _serviceManager.UserService.UpdateUserProfileAsync(userId, userProfileDTO, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("userprofile")]
        public async Task<IActionResult> DeleteUserProfileById(string userId)
        {
            await _serviceManager.UserService.DeleteUserProfileAsync(userId, trackChanges: false);

            return NoContent();
        }
    }
}
