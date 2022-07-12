using AssetMon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetMon.Data
{
    public class AssetMonContext: IdentityDbContext<AppUser>
    {
        public AssetMonContext(DbContextOptions<AssetMonContext> options) : base(options)    
        {

        }

        public DbSet<AppUser> User { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
