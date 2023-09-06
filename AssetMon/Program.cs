using AspNetCoreRateLimit;
using AssetMon.Commons.ActionFilters;
using AssetMon.Data;
using AssetMon.Main.Extensions;
using AssetMon.Models.ConfigurationModels;
using AssetMon.Services.Implementation;
using AssetMon.Services.Interface;
using AssetMon.Services.TemplateEngine;
using LoggerService.Interface;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

var build = new ConfigurationBuilder()
        .AddJsonFile($"appsettings.json", optional: true); //or what ever file you have the settings


IConfiguration configuration = build.Build();

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureVersioning();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITemplateEngine, TemplateEngine>();
builder.Services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
builder.Services.Configure<MailConfiguration>(configuration.GetSection("MailConfiguration"));

//Caching configuration
//builder.Services.ConfigureResponseCaching();
//builder.Services.ConfigureHttpCacheHeaders();

//Rate limiting configuration
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor(); 

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddApplicationPart(typeof(AssetMon.Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ValidationFilterAttribute>();


builder.Services.AddDbContext<AssetMonContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AssetMonDb")));


var app = builder.Build();


// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Asset Monitor API v1");
});
//if (app.Environment.IsDevelopment())
//{

//}
//else
//    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseIpRateLimiting();

app.UseCors("CorsPolicy");

//app.UseResponseCaching();
//app.UseHttpCacheHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
