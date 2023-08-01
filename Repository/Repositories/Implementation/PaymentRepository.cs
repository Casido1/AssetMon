using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(AssetMonContext context) : base(context)
        {
        }
    }
}
