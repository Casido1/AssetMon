using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IVehicleRepository Vehicle { get; }
        IPaymentRepository Payment { get; }
        void Save();
    }
}
