using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class Repair
    {
        public string Id { get; set; }
        public string AssetId { get; set; }
        public string RepairName { get; set; }
        public decimal Amount { get; set; }

        //Nav prop
        public virtual Asset Asset { get; set; }
        public Repair()
        {
            Id = Guid.NewGuid().ToString(); 
        }
    }
}
