using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Services.Interface
{
    public interface IVehicleService
    {
        Task<(ResultDTO<IEnumerable<VehicleDTO>> vehicles, MetaData metaData)> GetAllVehiclesAsync(VehicleParameters vehicleParameters, bool trackChanges);
        Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges);
        Task<ResultDTO<IEnumerable<VehicleDTO>>> GetVehiclesByIdsAsync(IEnumerable<string> Id, bool trackChanges);
        Task<VehicleDTO> CreateVehicleAsync(VehicleToCreateDTO vehicle);
        Task<(IEnumerable<VehicleDTO> vehicles, string Ids)> CreateVehicleCollectionAsync(IEnumerable<VehicleToCreateDTO> vehicleCollection);
        Task DeleteVehicleAsync(string vehicleId, bool trackChanges);
        Task UpdateVehicleAsync(string vehicleId, VehicleToUpdateDTO vehicleToUpdateDTO, bool trackChanges);
    }
}
