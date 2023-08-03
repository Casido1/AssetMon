using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Enums
{
    public enum PaymentFrequency
    {
        [Description("Daily")]
        Daily = 1,
        [Description("Weekly")]
        Weekly = 2,
        [Description("Monthly")]
        Monthly = 3
    }
}
