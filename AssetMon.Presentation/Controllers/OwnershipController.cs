using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/ownership")]
    [ApiController]
    public class OwnershipController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OwnershipController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateOwnership([FromBody] OwnershipDTO ownershipDTO)
        {
            await _serviceManager.OwnershipService.CreateOwnershipAsync(ownershipDTO.UserId, ownershipDTO.VehicleId, trackChanges: false);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOwnership([FromBody] OwnershipDTO ownershipDTO)
        {
            await _serviceManager.OwnershipService.UpdateOwnershipAsync(ownershipDTO.UserId, ownershipDTO.VehicleId, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{userId}/{vehicleId}")]
        public async Task<IActionResult> DeleteOwnership(string userId, string vehicleId)
        {
            await _serviceManager.OwnershipService.DeleteOwnershipAsync(userId, vehicleId, trackChanges: false);

            return NoContent();
        }

    }
}
