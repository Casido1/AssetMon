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
        Task<IEnumerable<Vehicle>> GetAllVehicles(bool trackChanges);
        Task<Vehicle> GetVehicleById(string Id, bool trackChanges);
        Task<IEnumerable<Vehicle>> GetVehiclesByIds(IEnumerable<string> Ids, bool trackChanges);
        Task CreateVehicle(Vehicle vehicle);
    }
}
