using Business_Logic;
using FluentApi;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddMemoryCache();
//SERVICES - injected by Dependency Injection
// Add services to the container.
builder.Services.AddControllers().AddXmlSerializerFormatters();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
        )
    );

Log.Logger = new LoggerConfiguration()
            .WriteTo.File(@"..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();
Log.Information("Program Starts");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("Trainerdb");
builder.Services.AddDbContext<TrainerDbContext>(Options => Options.UseSqlServer(config));
builder.Services.AddScoped<IData, EfRepo>();
builder.Services.AddScoped<ILog, Logic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
