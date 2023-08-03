using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
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
        public async Task<IActionResult> GetPaymentsAsync(string vehicleId)
        {
            var payments = await _service.PaymentService.GetPaymentsAsync(vehicleId, trackChanges: false);
            return Ok(payments);
        }

        [HttpGet("{Id}", Name = "PaymentByIdAsync")]
        public async Task<IActionResult> GetPaymentByIdAsync(string vehicleId, string Id)
        {
            var payments = await _service.PaymentService.GetPaymentByIdAsync(vehicleId, Id, trackChanges: false);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentAsync(string vehicleId, PaymentToCreateDTO payment)
        {
            if (payment == null) return BadRequest("PaymentToCreateDTO object is null");

            var paymentCreated = await _service.PaymentService.CreatePaymentAsync(vehicleId, payment, trackChanges: false);

            return CreatedAtRoute("PaymentByIdAsync", new {vehicleId, Id = paymentCreated.Id }, paymentCreated);
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> GetVehiclePaymentsByDateRange(string? vehicleId, DateTime startDate, DateTime endDate)
        {
            var payments = await _service.PaymentService.GetVehiclePaymentsByDateAsync(vehicleId, startDate, endDate, trackChanges: false);
            return Ok(payments);
        }
    }
}
