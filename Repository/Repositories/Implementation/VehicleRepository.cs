using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class VehicleRepository : RepositoryBase <Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreateVehicle(Vehicle vehicle)
        {
            Create(vehicle);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles(bool trackChanges)
        {
            return await FindAll(trackChanges)
                            .OrderBy(x => x.Name)
                            .ToListAsync();
        }      

        public async Task<Vehicle> GetVehicleById(string Id, bool trackChanges)
        {
            return await FindByCondition(v => v.Id == Id, trackChanges)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByIds(IEnumerable<string> Ids, bool trackChanges)
        {
            return await FindByCondition(v => Ids.Contains(v.Id), trackChanges)
                            .ToListAsync();
        }
    }
}
