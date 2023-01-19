using System;
using CarRenting.Application.Queries.CarQueries;
using CarRenting.Domain;
using CarRenting.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICarFilterQuery, CarFilterQuery>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddDbContext<CarRentingDbContext>(s => s.UseSqlite("filename=test.sqlite"));

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<CarRentingDbContext>().Database.Migrate();
}
app.Run();
