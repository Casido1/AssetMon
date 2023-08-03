using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.Exceptions;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using LoggerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var vehicle = await _repository.Vehicle.GetVehicleById(vehicleId, trackChanges);

            if(vehicle == null) 
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var paymentEntity = _mapper.Map<Payment>(payment);
            paymentEntity.VehicleId = vehicleId;

            await _repository.Payment.CreatePayment(paymentEntity);
            _repository.Save();

            var mappedEntity = _mapper.Map<PaymentDTO>(paymentEntity);
            return mappedEntity;
        }

        public async Task<ResultDTO<PaymentDTO>> GetPaymentByIdAsync(string vehicleId, string Id, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleById(vehicleId, trackChanges);

            if(vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payment = _repository.Payment.GetPaymentById(vehicleId, Id, trackChanges);
            var mappedEntity = _mapper.Map<PaymentDTO>(payment);

            return new ResultDTO<PaymentDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<IEnumerable<PaymentDTO>>> GetPaymentsAsync(string vehicleId, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleById(vehicleId, trackChanges);

            if(vehicle == null)
            {
                throw new VehicleNotFoundException(vehicleId);
            }

            var payments = await _repository.Payment.GetPayments(vehicleId, trackChanges);

            if (payments.Count() == 0)
            {
                return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Message = "No payments found for this vehicle" };
            }

            var mappedEntity = _mapper.Map<List<PaymentDTO>>(payments);
            return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Data = mappedEntity };
        }
    }
}
