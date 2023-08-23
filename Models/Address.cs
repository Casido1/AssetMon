using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssetMon.Models
{
    public class Address
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        //Nav prop
        [JsonIgnore]
        public virtual UserProfile UserProfile { get; set; }

        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
