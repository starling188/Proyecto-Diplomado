using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Extensions;
using Api.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Conection");
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(connection));

builder.Services.ExtensionRepository(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Automaper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
