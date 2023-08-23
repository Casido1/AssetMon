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
        public DbSet<VehicleRepair> VehicleRepairs { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ownership>()
                .HasKey(av => new { av.AppUserId, av.VehicleId });

            builder.Entity<Ownership>()
                .HasOne(av => av.AppUser)
                .WithMany(u => u.Ownerships)
                .HasForeignKey(av => av.AppUserId);

            builder.Entity<Ownership>()
                .HasOne(av => av.Vehicle)
                .WithMany(v => v.Ownerships)
                .HasForeignKey(av => av.VehicleId);


            //builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new VehicleConfiguration());
            //builder.ApplyConfiguration(new AddressConfiguration());
            //builder.ApplyConfiguration(new RepairConfiguration());
            //builder.ApplyConfiguration(new OwnershipConfiguration());
        }
    }
}
