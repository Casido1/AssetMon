using AssetMon.Data;
using AssetMon.Models;
using Microsoft.AspNetCore.Identity;

namespace AssetMon.UI.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(u =>
            {
                u.User.RequireUniqueEmail = true;
                u.Password.RequireNonAlphanumeric = true;
                u.Password.RequireUppercase = true;
                u.Password.RequireLowercase = true;
                u.Password.RequireDigit = true;
                u.Password.RequiredLength = 8;

            });
            builder.AddEntityFrameworkStores<AssetMonContext>().AddDefaultTokenProviders();
        }

    }
}
