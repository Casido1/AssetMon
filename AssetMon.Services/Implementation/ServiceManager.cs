using AssetMon.Data.Repositories.Interface;
using AssetMon.Services.Interface;
using LoggerService.Interface;

namespace AssetMon.Services.Implementation
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly Lazy<IVehicleService> _vehicleService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
            _vehicleService = new Lazy<IVehicleService>(() =>new VehicleService(_repository, _logger));
            _userService = new Lazy<IUserService>(() =>new UserService(_repository, _logger));  
        }
        public IUserService UserService => _userService.Value;

        public IVehicleService VehicleService => _vehicleService.Value;
    }
}
