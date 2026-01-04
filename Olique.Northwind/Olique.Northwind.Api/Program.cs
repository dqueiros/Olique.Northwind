using Microsoft.EntityFrameworkCore;
using Olique.Northwind.Application.Interfaces;
using Olique.Northwind.Application.Services;
using Olique.Northwind.Domain.Interfaces;
using Olique.Northwind.Infrastructure.Context;
using Olique.Northwind.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Infrastructure (Repository)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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
