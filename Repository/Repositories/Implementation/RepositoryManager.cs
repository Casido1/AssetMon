using AssetMon.Data.Repositories.Interface;

namespace AssetMon.Data.Repositories.Implementation
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AssetMonContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IVehicleRepository> _vehicleRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IOwnershipRepository> _ownershipRepository;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<IRepairRepository> _repairRepository;

        public RepositoryManager(AssetMonContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _vehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(_context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_context));
            _ownershipRepository = new Lazy<IOwnershipRepository>(() => new OwnershipRepository(_context));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(_context));
            _repairRepository = new Lazy<IRepairRepository>(() => new RepairRepository(_context));
        }
        public IUserRepository User => _userRepository.Value;

        public IVehicleRepository Vehicle => _vehicleRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public IOwnershipRepository Ownership => _ownershipRepository.Value;

        public IAddressRepository Address => _addressRepository.Value;

        public IRepairRepository Repair => _repairRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
