using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<PagedList<UserProfile>> GetUserProfilesAsync(UserParameters userParameters, bool trackChanges);
        Task<UserProfile> GetUserProfileByIdAsync(string userId, bool trackChanges);
        Task CreateUserProfileAsync(UserProfile userProfile);
        Task DeleteUserProfileAsync(UserProfile userProfile);
    }
}
