using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
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

        public async Task<PaymentDTO> CreatePaymentAsync(string vehicleId, PaymentToCreateDTO payment, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if(vehicle == null) 
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var paymentEntity = _mapper.Map<Payment>(payment);
            paymentEntity.VehicleId = vehicleId;

            await _repository.Payment.CreatePaymentAsync(paymentEntity);
            await _repository.SaveAsync();

            var mappedEntity = _mapper.Map<PaymentDTO>(paymentEntity);
            return mappedEntity;
        }

        public async Task DeleteVehiclePaymentAsync(string vehicleId, string paymentId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if (vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payment = await _repository.Payment.GetPaymentByIdAsync(vehicleId, paymentId, trackChanges);

            if (payment == null)
            {
                throw new PaymentNotFoundException(paymentId);
            }

            await _repository.Payment.DeleteVehiclePaymentAsync(payment);
            await _repository.SaveAsync();
        }

        public async Task<ResultDTO<PaymentDTO>> GetPaymentByIdAsync(string vehicleId, string Id, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if(vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payment = _repository.Payment.GetPaymentByIdAsync(vehicleId, Id, trackChanges);

            if(payment == null)
            {
                throw new PaymentNotFoundException(vehicleId);
            }

            var mappedEntity = _mapper.Map<PaymentDTO>(payment);

            return new ResultDTO<PaymentDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<IEnumerable<PaymentDTO>>> GetPaymentsAsync(string vehicleId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if(vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payments = await _repository.Payment.GetPaymentsAsync(vehicleId, trackChanges);

            if (payments.Count() == 0)
            {
                return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Message = "No payments found for this vehicle" };
            }

            var mappedEntity = _mapper.Map<List<PaymentDTO>>(payments);
            return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<IEnumerable<PaymentDTO>>> GetVehiclePaymentsByDateAsync(string vehicleId, DateTime startDate, DateTime endDate, bool trackChanges)
        {
            var vehicle = _repository.Vehicle.GetVehicleByIdAsync(vehicleId, trackChanges);

            if( vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payments = await _repository.Payment.GetVehiclePaymentsByDateRangeAsync(vehicleId, startDate, endDate, trackChanges);

            if (payments.Count() == 0)
            {
                return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Message = "No payments found for this date range" };
            }

            var mappedEntity = _mapper.Map<List<PaymentDTO>>(payments);
            return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Data = mappedEntity };
        }

        public async Task UpdateVehiclePaymentAsync(string vehicleId, string paymentId, PaymentToUpdateDTO paymentToUpdateDTO, bool trackVehicleChanges, bool trackVehiclePaymentChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleByIdAsync(paymentId, trackVehicleChanges);

            if(vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payment = await _repository.Payment.GetPaymentByIdAsync(vehicleId, paymentId, trackVehiclePaymentChanges);

            if( payment == null)
            {
                throw new PaymentNotFoundException(paymentId);
            }

            _mapper.Map(paymentToUpdateDTO, payment);
            await _repository.SaveAsync();
        }
    }
}
