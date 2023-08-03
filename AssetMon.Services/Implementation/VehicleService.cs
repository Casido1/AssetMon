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
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Implementation
{
    internal sealed class VehicleService : IVehicleService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public VehicleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> CreateVehicleAsync(VehicleToCreateDTO vehicle)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicle);

            await _repository.Vehicle.CreateVehicle(vehicleEntity);
            _repository.Save();

            var vehicleToReturn = _mapper.Map<VehicleDTO>(vehicleEntity);
            return vehicleToReturn;
        }

        public async Task<(IEnumerable<VehicleDTO> vehicles, string Ids)> CreateVehicleCollectionAsync(IEnumerable<VehicleToCreateDTO> vehicleCollection)
        {
            if(vehicleCollection == null)
            {
                throw new VehicleCollectionRequest();
            }

            var vehicleEntities = _mapper.Map<IEnumerable<Vehicle>>(vehicleCollection);

            foreach ( var vehicleEntity in vehicleEntities)
            {
                await _repository.Vehicle.CreateVehicle(vehicleEntity);
            }
            _repository.Save();

            var mappedEntities = _mapper.Map<IEnumerable<VehicleDTO>>(vehicleEntities);
            var Ids = string.Join(",", mappedEntities.Select(v => v.Id));
            return (mappedEntities,  Ids);
        }

        public async Task<ResultDTO<IEnumerable<VehicleDTO>>> GetAllVehiclesAsync(bool trackChanges)
        {
            var vehicles = await _repository.Vehicle.GetAllVehicles(trackChanges);

            var mappedEntity = _mapper.Map<List<VehicleDTO>>(vehicles);

            return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<VehicleDTO>> GetVehicleByIdAsync(string Id, bool trackChanges)
        {
            var vehicle = await _repository.Vehicle.GetVehicleById(Id, trackChanges);

            if (vehicle == null)
            {
                throw new VehicleNotFoundException(Id);
            }

            var mappedEntity = _mapper.Map<VehicleDTO>(vehicle);
            return new ResultDTO<VehicleDTO> { Success = true, Data = mappedEntity };
        }

        public async Task<ResultDTO<IEnumerable<VehicleDTO>>> GetVehiclesByIdsAsync(IEnumerable<string> Ids, bool trackChanges)
        {
            if(Ids is null)
            {
                throw new IdParametersBadRequestException();
            }

            var vehicles = await _repository.Vehicle.GetVehiclesByIds(Ids, trackChanges);

            if(Ids.Count() != vehicles.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var mappedEntity = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
            return new ResultDTO<IEnumerable<VehicleDTO>> { Success = true, Data = mappedEntity };
        }
    }
}
