using AssetMon.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserProfileByIdAsync(string userId, bool trackChanges);
        Task CreateUserProfileAsync(UserProfile userProfile);
    }
}
