using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace AssetMon.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AddressService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateUserAddressAsync(string userId, AddressToCreateDTO addressToCreateDTO, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var mappedEntity = _mapper.Map<Address>(addressToCreateDTO);
            mappedEntity.UserProfileId = userId;

            await _repository.Address.CreateUserAddressAsync(mappedEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteUserAddressAsync(string userId, bool trackChanges)
        {
            var address = await CheckIfExistsAndGetUserAddress(userId, trackChanges);

            await _repository.Address.DeleteUserAddressAsync(address);
            await _repository.SaveAsync();
        }

        public async Task UpdateUserAddressAsync(string userId, AddressToUpdateDTO addressToUpdateDTO, bool trackChanges)
        {
            var address = await CheckIfExistsAndGetUserAddress(userId, trackChanges);

            _mapper.Map(addressToUpdateDTO, address);
            await _repository.SaveAsync();
        }

        private async Task CheckIfUserExists(string userId, bool trackChanges)
        {
            var userProfile = await _repository.User.GetUserProfileByIdAsync(userId, trackChanges);

            if (userProfile == null)
            {
                throw new UserProfileNotFoundException(userId);
            }
        }

        private async Task<Address> CheckIfExistsAndGetUserAddress(string userId, bool trackChanges)
        {
            var address = await _repository.Address.GetAddressByUserIdAsync(userId, trackChanges);

            if (address == null)
            {
                throw new UserProfileNotFoundException(userId);
            }

            return address;
        }
    }
}
