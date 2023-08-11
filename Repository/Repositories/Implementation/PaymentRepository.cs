using AssetMon.Data.Repositories.Extensions;
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
                            .FilterPayments(paymentParameters.StartDate, paymentParameters.EndDate)
                            .OrderBy(p => p.Date)
                            .Skip((paymentParameters.PageNumber - 1) * paymentParameters.PageSize)
                            .Take(paymentParameters.PageSize)
                            .ToListAsync();

            var count = await FindByCondition(p => p.VehicleId.Equals(vehicleId), trackChanges).CountAsync();

            return new PagedList<Payment>(payments, count, paymentParameters.PageNumber, paymentParameters.PageSize);
        }
    }
}
