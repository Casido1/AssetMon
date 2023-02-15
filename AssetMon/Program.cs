using AssetMon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using AssetMon.Models;
using AssetMon.UI.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityCore<AppUser>(u => u.User.RequireUniqueEmail = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var build = new ConfigurationBuilder()
        .AddJsonFile($"appsettings.json", optional: true); //or what ever file you have the settings


IConfiguration configuration = build.Build();

builder.Services.AddDbContext<AssetMonContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AssetMonDb")));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.ConfigureIdentity();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
