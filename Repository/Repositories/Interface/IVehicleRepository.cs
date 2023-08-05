using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(bool trackChanges);
        Task<Vehicle> GetVehicleByIdAsync(string Id, bool trackChanges);
        Task<IEnumerable<Vehicle>> GetVehiclesByIdsAsync(IEnumerable<string> Ids, bool trackChanges);
        Task CreateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Vehicle vehicle);
    }
}
