using AssetMon.Data.Repositories.Extensions;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;
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
            return await FindByCondition(u => u.AppUserId == userId, trackChanges)
                        .Include(a => a.Address)
                        .Include(p => p.Pictures)
                        .FirstOrDefaultAsync();
        }

        public async Task<PagedList<UserProfile>> GetUserProfilesAsync(UserParameters userParameters, bool trackChanges)
        {
            var users = await FindAll(trackChanges)
                                .Include(a => a.Address)    
                                .FilterUsers(userParameters.StartDate, userParameters.EndDate)
                                .Search(userParameters.SearchTerm)
                                .Sort(userParameters.OrderBy)
                                .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                                .Take(userParameters.PageSize)
                                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<UserProfile>(users, count, userParameters.PageNumber, userParameters.PageSize);
        }
    }
}
