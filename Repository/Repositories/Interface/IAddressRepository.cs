using AssetMon.Models;
using AssetMon.Shared.DTOs;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressByUserIdAsync(string userId, bool trackChanges);
        Task CreateAddressAsync(Address address);
        Task DeleteAddressAsync(string userId);
    }
}
