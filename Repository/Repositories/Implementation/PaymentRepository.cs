using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreatePayment(Payment payment)
        {
            Create(payment);
        }

        public async Task<Payment> GetPaymentById(string vehicleId, string Id, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId && p.Id == Id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetPayments(string vehicleId, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId, trackChanges)
                            .OrderBy(p => p.Date)
                            .ToListAsync();
        }
    }
}
