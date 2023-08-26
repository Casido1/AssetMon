using AssetMon.Data.Repositories.Extensions;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class RepairRepository : RepositoryBase<VehicleRepair>, IRepairRepository
    {
        public RepairRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreateVehicleRepairAsync(VehicleRepair vehicleRepair)
        {
            Create(vehicleRepair);
        }

        public async Task DeleteVehicleRepairAsync(VehicleRepair vehicleRepair)
        {
            Delete(vehicleRepair);
        }

        public async Task<VehicleRepair> GetVehicleRepairByIdAsync(string vehicleId, string Id, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId && p.Id == Id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<PagedList<VehicleRepair>> GetVehicleRepairsAsync(string vehicleId, VehicleRepairParameters vehicleRepairParameters, bool trackChanges)
        {
            var repairs = await FindByCondition(p => p.VehicleId == vehicleId, trackChanges)
                            .FilterVehicleRepairs(vehicleRepairParameters.StartDate, vehicleRepairParameters.EndDate)
                            .Sort(vehicleRepairParameters.OrderBy)
                            .Skip((vehicleRepairParameters.PageNumber - 1) * vehicleRepairParameters.PageSize)
                            .Take(vehicleRepairParameters.PageSize)
                            .ToListAsync();

            var count = await FindByCondition(p => p.VehicleId.Equals(vehicleId), trackChanges).CountAsync();

            return new PagedList<VehicleRepair>(repairs, count, vehicleRepairParameters.PageNumber, vehicleRepairParameters.PageSize);
        }
    }
}
