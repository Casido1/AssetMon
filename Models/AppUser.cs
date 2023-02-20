using Microsoft.AspNetCore.Identity;

namespace AssetMon.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }

        //nav prop
        public virtual Address Address { get; set; }
        public virtual IEnumerable<Asset> Assets { get; set; }

        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            Assets = new List<Asset>();
        }

    }
}
