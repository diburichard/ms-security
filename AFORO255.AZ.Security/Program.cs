using AFORO255.AZ.Security.Components;
using AFORO255.AZ.Security.Data;
using AFORO255.AZ.Security.Repositories;
using AFORO255.AZ.Security.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnAppConfig = builder.Configuration["CONFIG_CN_APP_EXTERNAL"];

builder.Host.ConfigureAppConfiguration(builder =>
builder.AddAzureAppConfiguration(
    opt => opt
    .Connect(cnAppConfig)
    .ConfigureRefresh(
        refr => refr.Register("VERSION", true)
        .SetCacheExpiration(TimeSpan.FromSeconds(5)))));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SecurityContext>(
               options => options.UseSqlServer(builder.Configuration["CONFIG_CN_SECURITY"]));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

DbCreated.CreateDbIfNotExists(app);
app.Run();
