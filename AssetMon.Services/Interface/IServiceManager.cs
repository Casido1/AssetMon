using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Interface
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IVehicleService VehicleService { get; }
        IPaymentService PaymentService { get; }
    }
}
