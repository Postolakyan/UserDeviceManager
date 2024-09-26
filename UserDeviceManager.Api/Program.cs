using Microsoft.EntityFrameworkCore;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.MappingProfiles;
using UserDeviceManager.Business.Services;
using UserDeviceManager.Data.Context;
using UserDeviceManager.Data.Interfaces;
using UserDeviceManager.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DeviceManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IDeviceService,DeviceService>();


builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfileDomain).Assembly);


builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
