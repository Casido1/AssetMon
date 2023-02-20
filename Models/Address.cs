using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetMon.Models
{
    public class Address
    {
        [Key, ForeignKey("AppUser")]
        public string Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        //Nav prop
        public virtual AppUser AppUser { get; set; }
    }
}
