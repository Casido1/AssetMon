using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AssetMon.Commons.Extensions;

namespace AssetMon.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public DateTime DateOfBirth { get; set; }

        public int GetAge() => DateOfBirth.GetAge();

        //Nav Prop
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; }

        public virtual Address Address { get; set; }

        public virtual List<Picture> Pictures { get; set; } = new List<Picture>();
    }
}
