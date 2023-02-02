using Business_Logic;
using FluentApi;
using FluentApi.Entities;
using Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("TrainerDb");
builder.Services.AddDbContext<TrainerDbContext>(options => options.UseSqlServer(config));
builder.Services.AddScoped<IData<FluentApi.Entities.TrainerDetaile>, EfRepo>();
builder.Services.AddScoped<ILog, Logic>();

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
