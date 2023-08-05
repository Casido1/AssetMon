using AssetMon.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class PaymentToUpdateDTO
    {
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
