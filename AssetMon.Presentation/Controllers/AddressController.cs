using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    [Route("api/user/userId/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AddressController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateUserAddress(string userId, [FromBody] AddressToCreateDTO addressToCreateDTO)
        {
            await _serviceManager.AddressService.CreateUserAddressAsync(userId, addressToCreateDTO, trackChanges: false);

            return NoContent();
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdateUserAddress(string userId, [FromBody] AddressToUpdateDTO addressToUpdateDTO)
        {
            await _serviceManager.AddressService.UpdateUserAddressAsync(userId, addressToUpdateDTO, trackChanges: true);

            return NoContent();
        }

        [HttpDelete]
        //[Authorize]
        public async Task<IActionResult> DeleteUserAddress(string userId)
        {
            await _serviceManager.AddressService.DeleteUserAddressAsync(userId, trackChanges: false);

            return NoContent(); 
        }
    }
}
