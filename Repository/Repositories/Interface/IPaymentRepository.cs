using AssetMon.Models;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments(string vehicleId, bool trackChanges);
        Task<Payment> GetPaymentById(string vehicleId, string Id, bool trackChanges);
        Task CreatePayment(Payment payment);
        Task<IEnumerable<Payment>> GetVehiclePaymentsByDateRange(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges);
    }
}
