using AssetMon.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetMon.Presentation.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PictureController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPicture([FromForm] IFormFile file)
        {
            using(var stream = file.OpenReadStream())
            {
                var publicId = await _serviceManager.PictureService.UploadPicture(stream, file.FileName);
                return Ok(publicId);
            }
        }

        [HttpGet("{publicId}")]
        public async Task<IActionResult> GetPicture(string publicId)
        {
            var imageUrl = await _serviceManager.PictureService.GetPictureUrl(publicId);
            return Ok(imageUrl);
        }
    }
}
