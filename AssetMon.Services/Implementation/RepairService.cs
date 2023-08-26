using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using AutoMapper;

namespace AssetMon.Services.Implementation
{
    public class RepairService : IRepairService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RepairService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VehicleRepairDTO> CreateVehiclePaymentAsync(string vehicleId, VehicleRepairToCreateDTO vehicleRepairToCreateDTO, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var repairEntity = _mapper.Map<VehicleRepair>(vehicleRepairToCreateDTO);
            repairEntity.VehicleId = vehicleId;

            await _repository.Repair.CreateVehicleRepairAsync(repairEntity);
            await _repository.SaveAsync();

            var mappedEntity = _mapper.Map<VehicleRepairDTO>(repairEntity);
            return mappedEntity;
        }

        public async Task DeleteVehicleRepairAsync(string vehicleId, string Id, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var repair = await CheckIfExistsAndGetVehicleRepair(vehicleId, Id, trackChanges);

            await _repository.Repair.DeleteVehicleRepairAsync(repair);
            await _repository.SaveAsync();
        }

        public async Task<ResultDTO<VehicleRepairDTO>> GetVehicleRepairByIdAsync(string vehicleId, string Id, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var repair = await CheckIfExistsAndGetVehicleRepair(vehicleId, Id, trackChanges);

            var mappedEntity = _mapper.Map<VehicleRepairDTO>(repair);

            return new ResultDTO<VehicleRepairDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<(ResultDTO<IEnumerable<VehicleRepairDTO>> vehicleRepairs, MetaData metaData)> GetVehicleRepairsAsync(string vehicleId, VehicleRepairParameters vehicleRepairParameters, bool trackChanges)
        {
            if (!vehicleRepairParameters.ValidDateRange) throw new MaxDateRangeBadRequestException();

            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var repairsWithMetaData = await _repository.Repair.GetVehicleRepairsAsync(vehicleId, vehicleRepairParameters, trackChanges);

            var mappedEntity = _mapper.Map<List<VehicleRepairDTO>>(repairsWithMetaData);
            return (vehicleRepairs: new ResultDTO<IEnumerable<VehicleRepairDTO>> { Success = true, Data = mappedEntity }, metaData: repairsWithMetaData.MetaData);
        }

        public async Task UpdateVehicleRepairAsync(string vehicleId, string Id, VehicleRepairToUpdateDTO vehicleRepairToUpdateDTO, bool trackVehicleChanges, bool trackVehicleRepairChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackVehicleChanges);

            var repair = await CheckIfExistsAndGetVehicleRepair(vehicleId, Id, trackVehicleRepairChanges);

            _mapper.Map(vehicleRepairToUpdateDTO, repair);
            await _repository.SaveAsync();
        }

        private async Task GetVehicleAndCheckIfExists(string vehicleId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if (vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }
        }

        private async Task<VehicleRepair> CheckIfExistsAndGetVehicleRepair(string vehicleId, string Id, bool trackChanges)
        {
            var repair = await _repository.Repair.GetVehicleRepairByIdAsync(vehicleId, Id, trackChanges);

            if (repair == null)
            {
                throw new PaymentNotFoundException(vehicleId);
            }

            return repair;
        }
    }
}
