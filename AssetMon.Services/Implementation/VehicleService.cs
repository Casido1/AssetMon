using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Services.Interface;
using AssetMon.Shared.DTOs;
using AutoMapper;
using LoggerService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Implementation
{
    internal sealed class VehicleService : IVehicleService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public VehicleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ResultDTO<IEnumerable<VehicleDTO>>> GetAllVehiclesAsync(bool trackChanges)
        {
            try
            {
                var vehicles = await _repository.Vehicle.GetAllVehicles(trackChanges);

                if (vehicles == null)
                {
                    return new ResultDTO<IEnumerable<VehicleDTO>> { Success = false, Message = "There was problem" };
                }

                if(vehicles.Count() == 0)
                {
                    return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Message = "No vehicle found" };
                }

                var mappedEntity = _mapper.Map<List<VehicleDTO>>(vehicles);
                return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedEntity };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllVehiclesAsync)} service method {ex}");
                return new ResultDTO<IEnumerable<VehicleDTO>> { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

        public async Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges)
        {
            try
            {
                var vehicle = await _repository.Vehicle.GetVehicleById(Id, trackChanges);

                if (vehicle == null)
                {
                    return new ResultDTO<VehicleDTO> { Success = false, Message = "Vehicle not found" };
                }

                var mappedEntity = _mapper.Map<VehicleDTO>(vehicle);
                return new ResultDTO<VehicleDTO> { Success = true, Data = mappedEntity };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllVehiclesAsync)} service method {ex}");
                return new ResultDTO<VehicleDTO> { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

        public async Task<ResultDTO<IEnumerable<PaymentDTO>>> GetVehiclePaymentsByVehicleIdAsync(string Id, bool trackChanges)
        {
            try
            {
                var payments = await _repository.Vehicle.GetVehiclePaymentsByVehicleId(Id, trackChanges);

                if (payments == null)
                {
                    return new ResultDTO<IEnumerable<PaymentDTO>> { Success = false, Message = "This vehicle does not exist" };
                }

                if (payments.Count() == 0)
                {
                    return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Message = "No payments found for this vehicle" };
                }

                var mappedEntity = _mapper.Map<List<PaymentDTO>>(payments);
                return new ResultDTO<IEnumerable<PaymentDTO>> { Success = true, Data = mappedEntity };
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError($"Something went wrong in the {nameof(GetAllVehiclesAsync)} service method {ex}");
                    return new ResultDTO<IEnumerable<PaymentDTO>> { Success = false, Message = $"An error occurred: {ex.Message}" };
                }
            }
        }
    }
}
