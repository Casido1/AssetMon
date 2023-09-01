using AssetMon.Data.Repositories.Implementation;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.ConfigurationModels;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AssetMon.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public PictureService(IOptions<CloudinarySettings> config, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            Account cloudinaryAccount = new Account(config.Value.CloudName, config.Value.Key, config.Value.Secret);
            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        public async Task<DeletionResult> DeletePictureAsync(string pictureId, string userId)
        {
            var user = await _repositoryManager.User.GetUserProfileByIdAsync(userId, trackChanges: true);

            if (user == null) throw new UserProfileNotFoundException(userId);

            var picture = user.Pictures.FirstOrDefault(x => x.Id == pictureId);

            if (picture == null) return null;

            if(picture.IsMain) return null;

            if(picture.PublicId != null)
            {
                var deleteParam = new DeletionParams(picture.PublicId);

                var result =  await _cloudinary.DestroyAsync(deleteParam);

                if (result.Error == null)
                {
                    user.Pictures.Remove(picture);
                    await _repositoryManager.SaveAsync();
                }
                return result;
            }
            return null;
        }

        public async Task<PictureDTO> UploadPictureAsync(IFormFile file, string userId)
        {
            var user = await _repositoryManager.User.GetUserProfileByIdAsync(userId, trackChanges: true);

            if (user == null) throw new UserProfileNotFoundException(userId);

            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParam = new ImageUploadParams
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("Fill").Gravity("face"),
                    Folder = "assetmon-images"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParam);
            }

            if (uploadResult.Error != null) return null;

            var picture = new Picture
            {
                PictureUrl = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };

            if (user.Pictures.Count() == 0) picture.IsMain = true;

            user.Pictures.Add(picture);

            await _repositoryManager.SaveAsync();

            var mappedResult = _mapper.Map<PictureDTO>(picture);

            return mappedResult;
        }
    }
}
