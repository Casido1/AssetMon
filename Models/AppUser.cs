using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace AssetMon.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public string PhotoUrl { get; set; }

        //nav prop
        public virtual IEnumerable<Ownership> Ownerships { get; set; }

        public virtual Address Address { get; set; }

        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            Ownerships = new List<Ownership>();
        }

    }
}
