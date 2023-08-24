using AssetMon.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/ownership/userId/vehicleId")]
    [ApiController]
    public class OwnershipController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OwnershipController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwnership(string userId, string vehicleId)
        {
            await _serviceManager.OwnershipService.CreateOwnershipAsync(userId, vehicleId, trackChanges: false);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOwnership(string userId, string vehicleId)
        {
            await _serviceManager.OwnershipService.UpdateOwnershipAsync(userId, vehicleId, trackChanges: true);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOwnership(string userId, string vehicleId)
        {
            await _serviceManager.OwnershipService.DeleteOwnershipAsync(userId, vehicleId, trackChanges: false);

            return NoContent();
        }

    }
}
