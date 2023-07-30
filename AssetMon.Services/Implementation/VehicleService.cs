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
        public IEnumerable<VehicleDTO> GetAllVehicles(bool trackChanges)
        {
            try
            {
                var vehicles = _repository.Vehicle.GetAllVehicles(trackChanges);
                return _mapper.Map<List<VehicleDTO>>(vehicles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllVehicles)} service method {ex}");
                throw;
            }
        }
    }
}
