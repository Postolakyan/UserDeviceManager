using Microsoft.EntityFrameworkCore;
using UserDeviceManager.Data.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DeviceManagerDbContext>(options=> options.UseSqlServer(connectionString));
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
