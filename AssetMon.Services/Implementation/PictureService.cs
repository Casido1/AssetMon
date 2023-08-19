using AssetMon.Services.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace AssetMon.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;

        public PictureService(IConfiguration configuration)
        {
            _configuration = configuration;
            var cloudinaryAPI = _configuration.GetSection("CloudinaryAPI");
            Account cloudinaryAccount = new Account(cloudinaryAPI["CloudName"], cloudinaryAPI["Key"], cloudinaryAPI["Secret"]);
            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        public async Task<string> GetPictureUrl(string pictureId)
        {
            var resource = await _cloudinary.GetResourceAsync(pictureId);
            return resource.Url.ToString();
        }

        public async Task<string> UploadPicture(Stream stream, string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Folder = "profile-pictures"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.PublicId;
        }
    }
}
