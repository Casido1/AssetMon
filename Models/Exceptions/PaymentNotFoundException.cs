using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Exceptions
{
    public class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(string paymentId) : base($"The payment with id: {paymentId} doesn't exist in the database.")
        {
                
        }
    }
}
