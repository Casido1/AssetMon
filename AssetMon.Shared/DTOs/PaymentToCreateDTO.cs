using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class PaymentToCreateDTO
    {
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
