using AssetMon.Commons.ActionFilters;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Presentation.Controllers
{
    [Route("api/vehicles/{vehicleId}/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PaymentsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehiclePayments(string vehicleId, [FromQuery] PaymentParameters paymentParameters)
        {
            var payments = await _service.PaymentService.GetVehiclePaymentsAsync(vehicleId, paymentParameters, trackChanges: false);

            return Ok(payments);
        }

        [HttpGet("{Id}", Name = "PaymentById")]
        public async Task<IActionResult> GetVehiclePaymentById(string vehicleId, string Id)
        {
            var payments = await _service.PaymentService.GetVehiclePaymentByIdAsync(vehicleId, Id, trackChanges: false);

            return Ok(payments);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVehiclePayment(string vehicleId, PaymentToCreateDTO payment)
        {
            var paymentCreated = await _service.PaymentService.CreateVehiclePaymentAsync(vehicleId, payment, trackChanges: false);

            return CreatedAtRoute("PaymentByIdc", new {vehicleId, Id = paymentCreated.Id }, paymentCreated);
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> GetVehiclePaymentsByDateRange(string? vehicleId, DateTime startDate, DateTime endDate)
        {
            var payments = await _service.PaymentService.GetVehiclePaymentsByDateAsync(vehicleId, startDate, endDate, trackChanges: false);

            return Ok(payments);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteVehiclePaymentById(string vehicleId, string Id)
        {
            await _service.PaymentService.DeleteVehiclePaymentAsync(vehicleId, Id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVehiclePayment(string vehicle, string Id, [FromBody] PaymentToUpdateDTO paymentToUpdateDTO)
        {
            await _service.PaymentService.UpdateVehiclePaymentAsync(vehicle, Id, paymentToUpdateDTO, trackVehicleChanges: false, trackVehiclePaymentChanges: true);
            
            return NoContent();
        }
    }
}
