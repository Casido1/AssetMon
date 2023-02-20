using AssetMon.Data.Configuration;
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

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new RepairConfiguration());
        }
    }
}
