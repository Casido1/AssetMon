using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Exceptions
{
    public sealed class MaxDateRangeBadRequestException : BadRequestException
    {
        public MaxDateRangeBadRequestException() : base("Max age can't be less than min age.")
        {
                
        }
    }
}
