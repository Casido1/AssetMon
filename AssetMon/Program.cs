using AssetMon.Data;
using Microsoft.EntityFrameworkCore;
using AssetMon.UI.ServiceExtensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using AssetMon.Main;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager(); 

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssetMon.Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

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
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
