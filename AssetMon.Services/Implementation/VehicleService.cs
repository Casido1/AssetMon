using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
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
                var mappedResult = _mapper.Map<List<VehicleDTO>>(vehicles);

                if (vehicles == null)
                {
                    return new ResultDTO<IEnumerable<VehicleDTO>> { Success = false, Message = "Entity not found" };
                }

                return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedResult };   
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllVehiclesAsync)} service method {ex}");
                return new ResultDTO<IEnumerable<VehicleDTO>> { Success = false, Message = "An error occurred: {ex.Message}" };
            }
        }

        public async Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges)
        {
            try
            {
                var vehicle = await _repository.Vehicle.GetVehicleById(Id, trackChanges);
                var mappedResult = _mapper.Map<VehicleDTO>(vehicle);

                if (vehicle == null)
                {
                    return new ResultDTO<VehicleDTO> { Success = false, Message = "Entity not found" };
                }

                return new ResultDTO<VehicleDTO> { Success = true, Data = mappedResult };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllVehiclesAsync)} service method {ex}");
                return new ResultDTO<VehicleDTO> { Success = false, Message = "An error occurred: {ex.Message}" };
            }
        }
    }
}
