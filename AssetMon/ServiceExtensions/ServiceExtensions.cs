using AssetMon.Data;
using AssetMon.Models;
using Logger.Contracts;
using LoggerService;
using Microsoft.AspNetCore.Identity;

namespace AssetMon.UI.ServiceExtensions
{
    public static class ServiceExtensions
    {
        #region Identity
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
        #endregion

        #region Cors
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
        #endregion

        #region IIS
        //This integration will help during deployment to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
        #endregion
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

    }
}
