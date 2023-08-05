using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
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

        [HttpGet("{Id}", Name = "VehicleByIdAsync")]
        public async Task<IActionResult> GetVehicleByIdAsync(string Id)
        {
            var vehicle = await _service.VehicleService.GetVehicleByIdAsync(Id, trackChanges: false);
            return Ok(vehicle);
        }

        [HttpGet("collection/{Ids}", Name = "VehiclesByIdsAsync")]
        public async Task<IActionResult> GetVehicleByIdsAsync(IEnumerable<string> Ids)
        {
            var vehicles = await _service.VehicleService.GetVehiclesByIdsAsync(Ids, trackChanges: false);
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] VehicleToCreateDTO vehicle)
        {
            if (vehicle == null) return BadRequest("VehicleToCreateDTO object is null");

            var createdVehicle = await _service.VehicleService.CreateVehicleAsync(vehicle);

            return CreatedAtRoute("VehicleByIdAsync", new { Id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateVehicleCollectionAsync([FromBody] IEnumerable<VehicleToCreateDTO> vehicleCollection)
        {
            var result = await _service.VehicleService.CreateVehicleCollectionAsync(vehicleCollection);
            return CreatedAtRoute("VehiclesByIdsAsync", new {result.Ids}, result.vehicles);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteVehicleAsync(string Id)
        {
            await _service.VehicleService.DeleteVehicleAsync(Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVehicleAsync(string Id, [FromBody] VehicleToUpdateDTO vehicleToUpdate)
        {
            if (vehicleToUpdate == null) return BadRequest("VehicleToUpdateDTO object is null");
            await _service.VehicleService.UpdateVehicleAsync(Id, vehicleToUpdate, trackChanges: true);

            return NoContent();
        }
    }
}
