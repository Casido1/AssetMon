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

        public async Task<IEnumerable<Vehicle>> GetAllVehicles(bool trackChanges)
        {
            return await FindAll(trackChanges)
                            .Include(a => a.Repairs)
                            .OrderBy(x => x.Name)
                            .ToListAsync();
        }      

        public async Task<Vehicle> GetVehicleById(string Id, bool trackChanges)
        {
            Expression<Func<Vehicle, bool>> expression = vehicle => vehicle.Id == Id;
            return await FindByCondition(expression, trackChanges).Include(a => a.Repairs).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetVehiclePaymentsByVehicleId(string Id, bool trackChanges)
        {
            Expression<Func<Vehicle, bool>> expression = vehicle => vehicle.Id == Id;
            var vehicle = await FindByCondition(expression, trackChanges).Include(a => a.Payments).FirstOrDefaultAsync();

            return vehicle == null ? null : vehicle.Payments;
        }
    }
}
