using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class VehicleRepository : RepositoryBase <Vehicle>, IVehicleRepository
    {
        private readonly AssetMonContext _context;
        public VehicleRepository(AssetMonContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAllVehicles(bool trackChanges) => 
            FindAll(trackChanges)
                  .Include(a => a.Repairs)
                  .OrderBy(x => x.Name)
                  .ToList();
    }
}
