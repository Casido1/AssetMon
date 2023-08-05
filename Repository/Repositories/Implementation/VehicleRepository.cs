using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class VehicleRepository : RepositoryBase <Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreateVehicleAsync(Vehicle vehicle)
        {
            Create(vehicle);
        }

        public async Task DeleteVehicleAsync(Vehicle vehicle)
        {
            Delete(vehicle);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                            .OrderBy(x => x.Name)
                            .ToListAsync();
        }      

        public async Task<Vehicle> GetVehicleByIdAsync(string Id, bool trackChanges)
        {
            return await FindByCondition(v => v.Id == Id, trackChanges)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByIdsAsync(IEnumerable<string> Ids, bool trackChanges)
        {
            return await FindByCondition(v => Ids.Contains(v.Id), trackChanges)
                            .ToListAsync();
        }
    }
}
