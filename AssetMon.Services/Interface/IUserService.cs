using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Services.Interface
{
    public interface IUserService
    {
        Task UpdateUserProfileAsync(string userId, UserProfileToUpdateDTO userProfileToUpdateDTO, bool trackChanges);
        Task<ResultDTO<UserProfileDTO>> GetUserProfileByIdAsync(string userId, bool trackChanges);
        Task<(ResultDTO<IEnumerable<UserProfileDTO>> users, MetaData metaData)> GetUserProfilesAsync(UserParameters userParameters, bool trackChanges);
        Task DeleteUserProfileAsync(string userId, bool trackChanges);
    }
}
