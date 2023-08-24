using AssetMon.Models;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserProfileByIdAsync(string userId, bool trackChanges);
        Task CreateUserProfileAsync(UserProfile userProfile);
        Task DeleteUserProfileAsync(UserProfile userProfile);
    }
}
