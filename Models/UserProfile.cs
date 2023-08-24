using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssetMon.Models
{
    public class UserProfile
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        //Nav Prop
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }

        public virtual Address Address { get; set; }
    }
}
