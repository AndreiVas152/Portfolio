using As.Park.Model;
using As.Park.Services.Contracts;
using As.Park.Services.Services;
using As.Park.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ParkDbContext>(o => { o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")); });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IPlateService, PlateService>();
builder.Services.AddScoped<IFineService, FineService>();
builder.Services.AddScoped<IVignetteService, VignetteService>();
builder.Services.AddTransient<ILoggerService, LoggerService>();
var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

LogManager.Setup().LoadConfigurationFromFile();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseRouting();
//app.MapControllerRoute(
//    name: "car",
//    pattern: "api/car/{action}/{id?}",
//    defaults: new { controller = "car", action = "index" });

app.Run();