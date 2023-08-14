using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using AutoMapper;

namespace AssetMon.Services.Implementation
{
    internal sealed class VehicleService : IVehicleService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public VehicleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> CreateVehicleAsync(VehicleToCreateDTO vehicle)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicle);

            await _repository.Vehicle.CreateVehicleAsync(vehicleEntity);
            await _repository.SaveAsync();

            var vehicleToReturn = _mapper.Map<VehicleDTO>(vehicleEntity);
            return vehicleToReturn;
        }

        public async Task<(IEnumerable<VehicleDTO> vehicles, string Ids)> CreateVehicleCollectionAsync(IEnumerable<VehicleToCreateDTO> vehicleCollection)
        {
            if(vehicleCollection == null)
            {
                throw new VehicleCollectionRequest();
            }

            var vehicleEntities = _mapper.Map<IEnumerable<Vehicle>>(vehicleCollection);

            foreach ( var vehicleEntity in vehicleEntities)
            {
                await _repository.Vehicle.CreateVehicleAsync(vehicleEntity);
            }
            await _repository.SaveAsync();

            var mappedEntities = _mapper.Map<IEnumerable<VehicleDTO>>(vehicleEntities);
            var Ids = string.Join(",", mappedEntities.Select(v => v.Id));
            return (mappedEntities,  Ids);
        }

        public async Task DeleteVehicleAsync(string vehicleId, bool trackChanges)
        {
            var vehicle = await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            await _repository.Vehicle.DeleteVehicleAsync(vehicle);
            await _repository.SaveAsync();
        }

        public async Task<(ResultDTO<IEnumerable<VehicleDTO>> vehicles, MetaData metaData)> GetAllVehiclesAsync(VehicleParameters vehicleParameters, bool trackChanges)
        {
            if (!vehicleParameters.ValidDateRange) throw new MaxDateRangeBadRequestException();
            
            var vehiclesWithMetaData = await _repository.Vehicle.GetAllVehiclesAsync(vehicleParameters, trackChanges);

            var mappedEntity = _mapper.Map<List<VehicleDTO>>(vehiclesWithMetaData);

            return (vehicles: new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedEntity }, metaData: vehiclesWithMetaData.MetaData);
        }

        public async Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges)
        {
            var vehicle = await GetVehicleAndCheckIfExists(Id, trackChanges);

            var mappedEntity = _mapper.Map<VehicleDTO>(vehicle);
            return new ResultDTO<VehicleDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<IEnumerable<VehicleDTO>>> GetVehiclesByIdsAsync(IEnumerable<string> Ids, bool trackChanges)
        {
            if(Ids is null)
            {
                throw new IdParametersBadRequestException();
            }

            var vehicles = await _repository.Vehicle.GetVehiclesByIdsAsync(Ids, trackChanges);

            if(Ids.Count() != vehicles.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var mappedEntity = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
            return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedEntity };
        }

        public async Task UpdateVehicleAsync(string vehicleId, VehicleToUpdateDTO vehicleToUpdateDTO, bool trackChanges)
        {
            var vehicle = await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            _mapper.Map(vehicleToUpdateDTO, vehicle);
            await _repository.SaveAsync();
        }

        private async Task<Vehicle> GetVehicleAndCheckIfExists(string vehicleId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if (vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            return vehicle;
        }
    }
}
