using MicroServ01.Application.Interfaces;
using MicroServ01.Application.Services;
using MicroServ01.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddScoped<ITablaService, TablaService>();
builder.Services.AddScoped<ITablaRepository, TablaRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Middleware
app.MapGet("/", () => "App Microservicio 01.");
app.MapControllers();

app.Run();