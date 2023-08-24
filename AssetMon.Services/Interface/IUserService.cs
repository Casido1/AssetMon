using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IUserService
    {
        Task UpdateUserProfileAsync(string userId, UserProfileDTO userProfileDTO, bool trackChanges);
        Task<ResultDTO<UserProfileDTO>> GetUserProfileByIdAsync(string userId, bool trackChanges);
        Task DeleteUserProfileAsync(string userId, bool trackChanges);
    }
}
