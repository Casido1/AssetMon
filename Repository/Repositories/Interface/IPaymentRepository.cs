using AssetMon.Models;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<PagedList<Payment>> GetVehiclePaymentsAsync(string vehicleId, PaymentParameters paymentParameters, bool trackChanges);
        Task<Payment> GetVehiclePaymentByIdAsync(string vehicleId, string Id, bool trackChanges);
        Task CreateVehiclePaymentAsync(Payment payment);
        Task<IEnumerable<Payment>> GetVehiclePaymentsByDateRangeAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges);
        Task DeleteVehiclePaymentAsync(Payment payment);
    }
}
