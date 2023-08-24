using AssetMon.Commons.ActionFilters;
using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AssetMon.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public VehiclesController(IServiceManager service) => _service = service;

        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetVehicles([FromQuery] VehicleParameters vehicleParameters)
        {
            var pagedResult = await _service.VehicleService.GetAllVehiclesAsync(vehicleParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.vehicles);
        }

        [HttpGet("{Id}", Name = "VehicleById")]
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] //this overrides the global cache configuration
        //[HttpCacheValidation(MustRevalidate = false)]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetVehicleById(string Id)
        {
            var vehicle = await _service.VehicleService.GetVehicleByIdAsync(Id, trackChanges: false);
            return Ok(vehicle);
        }

        [HttpGet("collection/{Ids}", Name = "VehiclesByIds")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetVehicleByIds(IEnumerable<string> Ids)
        {
            var vehicles = await _service.VehicleService.GetVehiclesByIdsAsync(Ids, trackChanges: false);
            return Ok(vehicles);
        }

        [HttpGet("byuserid{Id}")]
        public async Task<IActionResult> GetVehiclesByUserId(string Id, [FromQuery] VehicleParameters vehicleParameters)
        {
            var pagedResult = await _service.VehicleService.GetVehiclesByUserIdAsync(Id, vehicleParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.vehicles);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleToCreateDTO vehicle)
        {
            var createdVehicle = await _service.VehicleService.CreateVehicleAsync(vehicle);

            return CreatedAtRoute("VehicleById", new { Id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVehicleCollection([FromBody] IEnumerable<VehicleToCreateDTO> vehicleCollection)
        {
            var result = await _service.VehicleService.CreateVehicleCollectionAsync(vehicleCollection);
            return CreatedAtRoute("VehiclesByIds", new {result.Ids}, result.vehicles);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteVehicle(string Id)
        {
            await _service.VehicleService.DeleteVehicleAsync(Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVehicle(string Id, [FromBody] VehicleToUpdateDTO vehicleToUpdate)
        {
            await _service.VehicleService.UpdateVehicleAsync(Id, vehicleToUpdate, trackChanges: true);

            return NoContent();
        }
    }
}
