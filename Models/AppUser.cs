
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhotoUrl { get; set; }
        public string ContractType { get; set; }

        //nav prop
        public Address Address { get; set; }
        public IEnumerable<Asset> Assets { get; set; }

        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            Assets = new List<Asset>();
        }

    }
}
