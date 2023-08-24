using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Services.Interface;
using AutoMapper;
using LoggerService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AssetMon.Services.Implementation
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly Lazy<IVehicleService> _vehicleService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IPictureService> _pictureService;
        private readonly Lazy<IOwnershipService> _ownershipService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<AppUser> userManager,
            IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _vehicleService = new Lazy<IVehicleService>(() => new VehicleService(_repository, _mapper));
            _userService = new Lazy<IUserService>(() => new UserService(_repository, _mapper));
            _paymentService = new Lazy<IPaymentService>(() => new PaymentService(_repository, _mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_logger, _userManager, _repository, _mapper, _configuration));
            _pictureService = new Lazy<IPictureService>(() => new PictureService(_configuration));
            _ownershipService = new Lazy<IOwnershipService>(() => new OwnershipService(_repository));
        }
        public IUserService UserService => _userService.Value;

        public IVehicleService VehicleService => _vehicleService.Value;

        public IPaymentService PaymentService => _paymentService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IPictureService PictureService => _pictureService.Value;

        public IOwnershipService OwnershipService => _ownershipService.Value;
    }
}
