using AssetMon.Services.Interface;
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
    }
}
