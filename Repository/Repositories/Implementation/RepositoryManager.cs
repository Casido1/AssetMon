using AssetMon.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AssetMonContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IVehicleRepository> _vehicleRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;

        public RepositoryManager(AssetMonContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _vehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(_context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_context));
        }
        public IUserRepository User => _userRepository.Value;

        public IVehicleRepository Vehicle => _vehicleRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
