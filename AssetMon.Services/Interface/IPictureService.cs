using AssetMon.Shared.DTOs;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace AssetMon.Services.Interface
{
    public interface IPictureService
    {
        Task<PictureDTO> UploadPictureAsync(IFormFile file, string userId);
        Task<DeletionResult> DeletePictureAsync(string publicId);
    }
}
