using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace AssetMon.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("userprofiles")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetUserProfiles([FromQuery] UserParameters userParameters) 
        {
            var pagedResult = await _serviceManager.UserService.GetUserProfilesAsync(userParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.users);
        }

        [HttpGet("userprofile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfileById()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _serviceManager.UserService.GetUserProfileByIdAsync(userId, trackChanges: false);

            return Ok(result);
        }

        [HttpPut("{userId}/userprofile")]
        //[Authorize(Roles = "Owner, Driver")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUserProfile(string userId, [FromBody] UserProfileToUpdateDTO userProfileToUpdate)
        {
            await _serviceManager.UserService.UpdateUserProfileAsync(userId, userProfileToUpdate, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{userId}/userprofile")]
        //[Authorize(Roles = "Owner, Driver")]
        public async Task<IActionResult> DeleteUserProfileById(string userId)
        {
            await _serviceManager.UserService.DeleteUserProfileAsync(userId, trackChanges: false);

            return NoContent();
        }
    }
}
