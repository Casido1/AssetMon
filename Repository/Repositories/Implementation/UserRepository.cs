using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class UserRepository : RepositoryBase<UserProfile>, IUserRepository
    {
        public UserRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreateUserProfileAsync(UserProfile userProfile)
        {
            Create(userProfile);
        }

        public async Task DeleteUserProfileAsync(UserProfile userProfile)
        {
            Delete(userProfile);
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(string userId, bool trackChanges)
        {
            return await FindByCondition(u => u.Id == userId, trackChanges).FirstOrDefaultAsync();
        }
    }
}
