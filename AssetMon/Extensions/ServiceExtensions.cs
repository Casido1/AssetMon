using AssetMon.Data;
using AssetMon.Data.Repositories.Implementation;
using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using AssetMon.Services.Implementation;
using AssetMon.Services.Interface;
using LoggerService.Implementation;
using LoggerService.Interface;
using Microsoft.AspNetCore.Identity;

namespace AssetMon.Main.Extensions
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

        #region Logger
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
        #endregion

        #region repository manager
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        #endregion

        #region service manager
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        #endregion

    }
}
