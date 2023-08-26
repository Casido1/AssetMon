using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Services.Interface
{
    public interface IRepairService
    {
        Task<(ResultDTO<IEnumerable<VehicleRepairDTO>> vehicleRepairs, MetaData metaData)> GetVehicleRepairsAsync(string vehicleId, VehicleRepairParameters vehicleRepairParameters, bool trackChanges);
        Task<ResultDTO<VehicleRepairDTO>> GetVehicleRepairByIdAsync(string vehicleId, string Id, bool trackChanges);
        Task<VehicleRepairDTO> CreateVehiclePaymentAsync(string vehicleId, VehicleRepairToCreateDTO vehicleRepairToCreateDTO, bool trackChanges);
        Task DeleteVehicleRepairAsync(string vehicleId, string Id, bool trackChanges);
        Task UpdateVehicleRepairAsync(string vehicleId, string Id, VehicleRepairToUpdateDTO vehicleRepairToUpdateDTO, bool trackVehicleChanges, bool trackVehicleRepairChanges);
    }
}
