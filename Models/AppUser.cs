using Microsoft.AspNetCore.Identity;

namespace AssetMon.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        //Nav prop
        public virtual IEnumerable<Ownership> Ownerships { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        

        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            Ownerships = new List<Ownership>();
        }

    }
}
