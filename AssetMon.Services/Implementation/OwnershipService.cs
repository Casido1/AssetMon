using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AutoMapper;

namespace AssetMon.Services.Implementation
{
    public class OwnershipService : IOwnershipService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OwnershipService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task CreateOwnershipAsync(string userId, string vehicleId, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserProfileByIdAsync(userId, trackChanges);
            var vehicle = await _repositoryManager.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if(user == null || vehicle == null)
            {
                throw new Exception("user or/and vehicle does not exist");
            }

            var ownership = new Ownership { AppUserId = userId, VehicleId = vehicleId };
            await _repositoryManager.Ownership.CreateOwnershipAsync(ownership);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteOwnershipAsync(string userId, string vehicleId, bool trackChanges)
        {
            var ownership = await CheckIfExistsAndGetOwnership(userId, vehicleId, trackChanges);

            await _repositoryManager.Ownership.DeleteOwnershipAsync(ownership);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateOwnershipAsync(string userId, string vehicleId, bool trackChanges)
        {
            var ownership = await CheckIfExistsAndGetOwnership(userId, vehicleId, trackChanges);

            ownership.AppUserId = userId;
            ownership.VehicleId = vehicleId;
            await _repositoryManager.SaveAsync();
        }

        private async Task<Ownership> CheckIfExistsAndGetOwnership(string userId, string vehicleId, bool trackChanges)
        {
            var ownership = await _repositoryManager.Ownership.GetOwnershipById(userId, vehicleId, trackChanges);

            if(ownership == null)
            {
                throw new OwnershipNotFoundException(userId, vehicleId);
            }

            return ownership;
        }
    }
}
