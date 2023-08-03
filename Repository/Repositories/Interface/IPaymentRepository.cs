using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments(string vehicleId, bool trackChanges);
    }
}
