using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<PagedList<Vehicle>> GetAllVehiclesAsync(VehicleParameters vehicleParameters, bool trackChanges);
        Task<Vehicle> GetVehicleByIdAsync(string Id, bool trackChanges);
        Task<PagedList<Vehicle>> GetVehiclesByUserIdAsync(string userId, VehicleParameters vehicleParameters, bool trackChanges);
        Task<IEnumerable<Vehicle>> GetVehiclesByIdsAsync(IEnumerable<string> Ids, bool trackChanges);
        Task CreateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
    }
}
