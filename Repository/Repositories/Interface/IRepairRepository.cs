using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IRepairRepository
    {
        Task<PagedList<VehicleRepair>> GetVehicleRepairsAsync(string vehicleId, VehicleRepairParameters vehicleRepairParameters, bool trackChanges);
        Task<VehicleRepair> GetVehicleRepairByIdAsync(string vehicleId, string Id, bool trackChanges);
        Task CreateVehicleRepairAsync(VehicleRepair vehicleRepair);
        Task DeleteVehicleRepairAsync(VehicleRepair vehicleRepair);
    }
}
