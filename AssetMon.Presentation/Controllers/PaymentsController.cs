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
    [Route("api/vehicles/{vehicleId}/payments")]
    [ApiController]
    [EmailConfirmed]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PaymentsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(Roles = "Administrator, Owner")]
        public async Task<IActionResult> GetVehiclePayments(string vehicleId, [FromQuery] PaymentParameters paymentParameters)
        {
            var pagedResult = await _service.PaymentService.GetVehiclePaymentsAsync(vehicleId, paymentParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.payments);
        }

        [HttpGet("{Id}", Name = "PaymentById")]
        public async Task<IActionResult> GetVehiclePaymentById(string vehicleId, string Id)
        {
            var payments = await _service.PaymentService.GetVehiclePaymentByIdAsync(vehicleId, Id, trackChanges: false);

            return Ok(payments);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Driver")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVehiclePayment(string vehicleId, PaymentToCreateDTO payment)
        {
            var paymentCreated = await _service.PaymentService.CreateVehiclePaymentAsync(vehicleId, payment, trackChanges: false);

            return CreatedAtRoute("PaymentByIdc", new {vehicleId, Id = paymentCreated.Id }, paymentCreated);
        }

        [HttpDelete("{Id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteVehiclePaymentById(string vehicleId, string Id)
        {
            await _service.PaymentService.DeleteVehiclePaymentAsync(vehicleId, Id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{Id}")]
        //[Authorize(Roles = "Administrator")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVehiclePayment(string vehicle, string Id, [FromBody] PaymentToUpdateDTO paymentToUpdateDTO)
        {
            await _service.PaymentService.UpdateVehiclePaymentAsync(vehicle, Id, paymentToUpdateDTO, trackVehicleChanges: false, trackVehiclePaymentChanges: true);
            
            return NoContent();
        }
    }
}
