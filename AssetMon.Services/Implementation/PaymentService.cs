using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AssetMon.Shared.RequestFeatures;
using AutoMapper;

namespace AssetMon.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PaymentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> CreateVehiclePaymentAsync(string vehicleId, PaymentToCreateDTO payment, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var paymentEntity = _mapper.Map<Payment>(payment);
            paymentEntity.VehicleId = vehicleId;

            await _repository.Payment.CreateVehiclePaymentAsync(paymentEntity);
            await _repository.SaveAsync();

            var mappedEntity = _mapper.Map<PaymentDTO>(paymentEntity);
            return mappedEntity;
        }

        public async Task DeleteVehiclePaymentAsync(string vehicleId, string paymentId, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var payment = await GetVehiclePaymentAndCheckIfExists(vehicleId, paymentId, trackChanges);

            await _repository.Payment.DeleteVehiclePaymentAsync(payment);
            await _repository.SaveAsync();
        }

        public async Task<ResultDTO<PaymentDTO>> GetVehiclePaymentByIdAsync(string vehicleId, string paymentId, bool trackChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var payment = await GetVehiclePaymentAndCheckIfExists(vehicleId, paymentId, trackChanges);

            var mappedEntity = _mapper.Map<PaymentDTO>(payment);

            return new ResultDTO<PaymentDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<(ResultDTO<IEnumerable<PaymentDTO>> payments, MetaData metaData)> GetVehiclePaymentsAsync(string vehicleId, PaymentParameters paymentParameters, bool trackChanges)
        {
            if (!paymentParameters.ValidDateRange) throw new MaxDateRangeBadRequestException();

            await GetVehicleAndCheckIfExists(vehicleId, trackChanges);

            var paymentsWithMetaData = await _repository.Payment.GetVehiclePaymentsAsync(vehicleId, paymentParameters, trackChanges);

            if (paymentsWithMetaData.Count() == 0)
            {
                return (payments: new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Message = "No payments found for this vehicle" }, metaData: paymentsWithMetaData.MetaData);
            }

            var mappedEntity = _mapper.Map<List<PaymentDTO>>(paymentsWithMetaData);
            return (payments: new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Data = mappedEntity }, metaData: paymentsWithMetaData.MetaData);
        }

        public async Task UpdateVehiclePaymentAsync(string vehicleId, string paymentId, PaymentToUpdateDTO paymentToUpdateDTO, bool trackVehicleChanges, bool trackVehiclePaymentChanges)
        {
            await GetVehicleAndCheckIfExists(vehicleId, trackVehicleChanges);

            var payment = await GetVehiclePaymentAndCheckIfExists(vehicleId, paymentId, trackVehiclePaymentChanges);

            _mapper.Map(paymentToUpdateDTO, payment);
            await _repository.SaveAsync();
        }

        private async Task GetVehicleAndCheckIfExists(string vehicleId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if (vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }
        }

        private async Task<Payment> GetVehiclePaymentAndCheckIfExists(string vehicleId, string paymentId, bool trackChanges)
        {
            var payment = await _repository.Payment.GetVehiclePaymentByIdAsync(vehicleId, paymentId, trackChanges);

            if (payment == null)
            {
                throw new PaymentNotFoundException(vehicleId);
            }

            return payment;
        }
    }
}
