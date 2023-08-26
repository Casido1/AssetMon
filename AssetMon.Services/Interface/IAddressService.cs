using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IAddressService
    {
        Task CreateUserAddressAsync(string userId, AddressToCreateDTO addressToCreateDTO, bool trackChanges);
        Task DeleteUserAddressAsync(string userId, bool trackChanges);
        Task UpdateUserAddressAsync(string userId, AddressToUpdateDTO addressToUpdateDTO, bool trackChanges);
    }
}

