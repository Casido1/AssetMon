using AssetMon.Models;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressByUserIdAsync(string userId, bool trackChanges);
        Task CreateUserAddressAsync(Address address);
        Task DeleteUserAddressAsync(Address address);
    }
}
