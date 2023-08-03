using AssetMon.Shared.DTOs;

namespace AssetMon.Services.Interface
{
    public interface IPaymentService
    {
        Task<ResultDTO<IEnumerable<PaymentDTO>>> GetPaymentsAsync(string vehicleId, bool trackChanges);
        Task<ResultDTO<PaymentDTO>> GetPaymentByIdAsync(string vehicleId, string Id, bool trackChanges);
        Task<PaymentDTO> CreatePaymentAsync(string vehicleId, PaymentToCreateDTO payment, bool trackChanges);
        Task<ResultDTO<IEnumerable<PaymentDTO>>> GetVehiclePaymentsByDateAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges);
    }
}
