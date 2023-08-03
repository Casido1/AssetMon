using AssetMon.Data.Repositories.Interface;
using AssetMon.Services.Interface;
using AutoMapper;
using LoggerService.Interface;

namespace AssetMon.Services.Implementation
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly Lazy<IVehicleService> _vehicleService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPaymentService> _paymentService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _vehicleService = new Lazy<IVehicleService>(() =>new VehicleService(_repository, _mapper));
            _userService = new Lazy<IUserService>(() =>new UserService(_repository, _mapper));
            _paymentService = new Lazy<IPaymentService>(() =>new PaymentService(_repository, _mapper));
        }
        public IUserService UserService => _userService.Value;

        public IVehicleService VehicleService => _vehicleService.Value;

        public IPaymentService PaymentService => _paymentService.Value;
    }
}
