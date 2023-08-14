using AssetMon.Data.Repositories.Extensions;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;
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

        public async Task<PagedList<Vehicle>> GetAllVehiclesAsync(VehicleParameters vehicleParameters, bool trackChanges)
        {
            var vehicles =  await FindAll(trackChanges)
                                    .FilterVehicles(vehicleParameters.StartDate, vehicleParameters.EndDate)
                                    .Search(vehicleParameters.SearchTerm)
                                    .Sort(vehicleParameters.OrderBy)
                                    .Skip((vehicleParameters.PageNumber - 1) * vehicleParameters.PageSize)
                                    .Take(vehicleParameters.PageSize)
                                    .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Vehicle>(vehicles, count, vehicleParameters.PageNumber, vehicleParameters.PageSize);
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
