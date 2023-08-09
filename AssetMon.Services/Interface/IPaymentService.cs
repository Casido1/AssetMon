using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;

namespace AssetMon.Services.Interface
{
    public interface IPaymentService
    {
        Task<(ResultDTO<IEnumerable<PaymentDTO>> payments, MetaData metaData)> GetVehiclePaymentsAsync(string vehicleId, PaymentParameters paymentParameters, bool trackChanges);
        Task<ResultDTO<PaymentDTO>> GetVehiclePaymentByIdAsync(string vehicleId, string paymentId, bool trackChanges);
        Task<PaymentDTO> CreateVehiclePaymentAsync(string vehicleId, PaymentToCreateDTO payment, bool trackChanges);
        Task<ResultDTO<IEnumerable<PaymentDTO>>> GetVehiclePaymentsByDateAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges);
        Task DeleteVehiclePaymentAsync(string vehicleId, string paymentId, bool trackChanges);
        Task UpdateVehiclePaymentAsync(string vehicleId, string paymentId, PaymentToUpdateDTO paymentToUpdateDTO, bool trackVehicleChanges, bool trackVehiclePaymentChanges);
    }
}
