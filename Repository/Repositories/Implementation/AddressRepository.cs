using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(AssetMonContext context) : base(context)
        {     
        }

        public async Task CreateAddressAsync(Address address)
        {
            Create(address);
        }

        public async Task DeleteAddressAsync(string userId)
        {
            var address = await GetAddressByUserIdAsync(userId, trackChanges: false);
            Delete(address);
        }

        public async Task<Address> GetAddressByUserIdAsync(string userId, bool trackChanges)
        {
            var address = await FindByCondition(a => a.UserProfileId == userId, trackChanges).FirstOrDefaultAsync();
            return address;
        }
    }
}
