using AssetMon.Commons.ActionFilters;
using AssetMon.Commons.Extensions;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AssetMon.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IRepositoryManager _repositoryManager;

        public UsersController(IServiceManager serviceManager, IRepositoryManager repositoryManager)
        {
            _serviceManager = serviceManager;
            _repositoryManager = repositoryManager;
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
            var userId = User.GetUserId();
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

        [HttpPost("add-photo")]
        [Authorize]
        public async Task<ActionResult<PictureDTO>> AddPhoto(IFormFile file)
        {
            var userId = User.GetUserId();

            var result = await _serviceManager.PictureService.UploadPictureAsync(file, userId);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-photo/{pictureId}")]
        [Authorize]
        public async Task<IActionResult> DeletePhoto(string pictureId)
        {
            var userId = User.GetUserId();

            var result = await _serviceManager.PictureService.DeletePictureAsync(pictureId, userId);

            if (result == null) return BadRequest();

            if(result.Error != null) return BadRequest(result.Error.Message);

            return Ok(result);
        }
    }
}
