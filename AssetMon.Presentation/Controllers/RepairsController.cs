using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AssetMon.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/vehicles/{vehicleId}/repairs")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RepairsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(Roles = "Administrator, Owner")]
        public async Task<IActionResult> GetVehicleRepairs(string vehicleId, [FromQuery] VehicleRepairParameters vehicleRepairParameters)
        {
            var pagedResult = await _service.RepairService.GetVehicleRepairsAsync(vehicleId, vehicleRepairParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.vehicleRepairs);
        }

        [HttpGet("{Id}", Name = "RepairById")]
        public async Task<IActionResult> GetVehicleRepairById(string vehicleId, string Id)
        {
            var repairs = await _service.RepairService.GetVehicleRepairByIdAsync(vehicleId, Id, trackChanges: false);

            return Ok(repairs);
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator, Driver")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVehicleRepair(string vehicleId, VehicleRepairToCreateDTO vehicleRepairToCreate)
        {
            var repairCreated = await _service.RepairService.CreateVehiclePaymentAsync(vehicleId, vehicleRepairToCreate, trackChanges: false);

            return CreatedAtRoute("RepairById", new { vehicleId, Id = repairCreated.Id }, repairCreated);
        }

        [HttpDelete("{Id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteVehicleRepairById(string vehicleId, string Id)
        {
            await _service.RepairService.DeleteVehicleRepairAsync(vehicleId, Id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{Id}")]
        //[Authorize(Roles = "Administrator")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVehicleRepair(string vehicle, string Id, [FromBody] VehicleRepairToUpdateDTO vehicleRepairToUpdateDTO)
        {
            await _service.RepairService.UpdateVehicleRepairAsync(vehicle, Id, vehicleRepairToUpdateDTO, trackVehicleChanges: false, trackVehicleRepairChanges: true);

            return NoContent();
        }
    }
}
