using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(AssetMonContext context) : base(context)
        {
        }

        public async Task CreateVehiclePaymentAsync(Payment payment)
        {
            Create(payment);
        }

        public async Task DeleteVehiclePaymentAsync(Payment payment)
        {
            Delete(payment);
        }

        public async Task<Payment> GetVehiclePaymentByIdAsync(string vehicleId, string Id, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId && p.Id == Id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Payment>> GetVehiclePaymentsAsync(string vehicleId, PaymentParameters paymentParameters, bool trackChanges)
        {
            var payments = await FindByCondition(p => p.VehicleId == vehicleId, trackChanges)
                            .OrderBy(p => p.Date)
                            .ToListAsync();

            return PagedList<Payment>
                    .ToPagedList(payments, paymentParameters.PageNumber, paymentParameters.PageSize);
        }

        public async Task<IEnumerable<Payment>> GetVehiclePaymentsByDateRangeAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges)
        {
            return await FindByCondition(p => p.VehicleId == vehicleId && (p.Date >= startDate && p.Date <= endDate), trackChanges)
                            .OrderBy(p => p.Date)   
                            .ToListAsync();
        }
    }
}
