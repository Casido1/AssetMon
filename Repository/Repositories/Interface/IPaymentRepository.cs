using AssetMon.Models;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync(string vehicleId, bool trackChanges);
        Task<Payment> GetPaymentByIdAsync(string vehicleId, string Id, bool trackChanges);
        Task CreatePaymentAsync(Payment payment);
        Task<IEnumerable<Payment>> GetVehiclePaymentsByDateRangeAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges);
        Task DeleteVehiclePaymentAsync(Payment payment);
    }
}
