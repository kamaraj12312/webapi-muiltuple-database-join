using Microsoft.EntityFrameworkCore;
using singleapi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var connectionString = builder.Configuration.GetConnectionString("UserDBConnection");
//builder.Services.AddDbContext<nameContext>(options => options.UseSqlServer("Data Source=10.50.51.117;Initial Catalog=TestDB;User ID=bms0176;Password=Welcome@123"));
//var connectionString = builder.Configuration.GetConnectionString("Data Source=10.50.51.117;Initial Catalog=TestDB;User ID=bms0176;Password=Welcome@123");
//builder.Services.AddDbContext<nameContext>(options => options.UseSqlServer("Data Source=10.50.51.117;Initial Catalog=TestDB;User ID=bms0176;Password=Welcome@123"));
//builder.Services.AddDbContext<nameContext>(option => option.UseSqlServer("UserDBConnection"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});
