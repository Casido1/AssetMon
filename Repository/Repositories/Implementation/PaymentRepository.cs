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
    internal sealed class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPayments(string vehicleId, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId, trackChanges)
                            .OrderBy(p => p.Date)
                            .ToListAsync();
        }
    }
}
