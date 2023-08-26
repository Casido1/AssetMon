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

        public async Task CreateUserAddressAsync(Address address)
        {
            Create(address);
        }

        public async Task DeleteAddressAsync(Address address)
        {
            Delete(address);
        }

        public Task DeleteUserAddressAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetAddressByUserIdAsync(string userId, bool trackChanges)
        {
            var address = await FindByCondition(a => a.UserProfileId == userId, trackChanges).FirstOrDefaultAsync();
            return address;
        }
    }
}
