using EmployeeAPI_Version1.Models;
using EmployeeAPI_Version1.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// This should be in the startup.cs - but this project starts with the program.cs ...
builder.Services.AddDbContext<EmployeeContext>(o => o.UseSqlite("Data source=employees.db"));
// Will register an instance of the EmployeeREpository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
