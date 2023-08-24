using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    public class OwnershipRepository : RepositoryBase<Ownership>, IOwnershipRepository
    {
        public OwnershipRepository(AssetMonContext context) : base(context)
        {      
        }
        public async Task CreateOwnershipAsync(Ownership ownership)
        {
            Create(ownership);
        }

        public async Task DeleteOwnershipAsync(Ownership ownership)
        {
            Delete(ownership);
        }

        public async Task<Ownership> GetOwnershipById(string userId, string vehicleId, bool trackChanges)
        {
            var ownership = await FindByCondition(o => o.AppUserId == userId && o.VehicleId == vehicleId, trackChanges).FirstOrDefaultAsync();

            return ownership;
        }
    }
}
