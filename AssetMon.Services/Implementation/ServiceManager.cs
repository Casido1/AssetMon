﻿using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Models.ConfigurationModels;
using AssetMon.Services.Interface;
using AutoMapper;
using LoggerService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AssetMon.Services.Implementation
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IConfiguration _configuration;
        private readonly Lazy<IVehicleService> _vehicleService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IPictureService> _pictureService;
        private readonly Lazy<IOwnershipService> _ownershipService;
        private readonly Lazy<IAddressService> _addressService;
        private readonly Lazy<IRepairService> _repairService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, IEmailService emailService, IConfiguration configuration,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _cloudinaryConfig = cloudinaryConfig;
            _configuration = configuration;
            _vehicleService = new Lazy<IVehicleService>(() => new VehicleService(_repository, _mapper));
            _userService = new Lazy<IUserService>(() => new UserService(_repository, _mapper));
            _paymentService = new Lazy<IPaymentService>(() => new PaymentService(_repository, _mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_logger, _userManager, _roleManager, _repository, _emailService, _mapper, _configuration));
            _pictureService = new Lazy<IPictureService>(() => new PictureService(_cloudinaryConfig, _repository, _mapper));
            _ownershipService = new Lazy<IOwnershipService>(() => new OwnershipService(_repository));
            _addressService = new Lazy<IAddressService>(() => new AddressService(_repository, _mapper));
            _repairService = new Lazy<IRepairService>(() => new  RepairService(_repository, _mapper));
        }
        public IUserService UserService => _userService.Value;

        public IVehicleService VehicleService => _vehicleService.Value;

        public IPaymentService PaymentService => _paymentService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IPictureService PictureService => _pictureService.Value;

        public IOwnershipService OwnershipService => _ownershipService.Value;

        public IAddressService AddressService => _addressService.Value;

        public IRepairService RepairService => _repairService.Value;
    }
}
