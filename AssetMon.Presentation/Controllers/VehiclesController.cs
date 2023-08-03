using AssetMon.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    [Route("api/Vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public VehiclesController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _service.VehicleService.GetAllVehiclesAsync(trackChanges: false);
            return Ok(vehicles);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetVehicleById(string Id)
        {
            var vehicle = await _service.VehicleService.GetVehicleByIdAsync(Id, trackChanges: false);
            return Ok(vehicle);
        }
    }
}
