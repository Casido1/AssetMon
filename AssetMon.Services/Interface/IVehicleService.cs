using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IVehicleService
    {
        Task<ResultDTO<IEnumerable<VehicleDTO>>> GetAllVehiclesAsync(bool trackChanges);
        Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges);
        Task<ResultDTO<IEnumerable<VehicleDTO>>> GetVehiclesByIdsAsync(IEnumerable<string> Id, bool trackChanges);
        Task<VehicleDTO> CreateVehicleAsync(VehicleToCreateDTO vehicle);
        Task<(IEnumerable<VehicleDTO> vehicles, string Ids)> CreateVehicleCollectionAsync(IEnumerable<VehicleToCreateDTO> vehicleCollection);
    }
}
