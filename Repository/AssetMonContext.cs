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

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
