using DesafioFinalClienteApi.Data;
using DesafioFinalClienteApi.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


// Adiciona os controllers ao serviço (mvc)
builder.Services.AddControllers();


// banco de dados em memória
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("ClientesDb"));


// ID
builder.Services.AddScoped<IClienteService, ClienteService>();


// Swagger + XML comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo
{
Title = "Cliente API",
Version = "v1",
Description = "API REST de Clientes (CRUD + extras) com EF Core InMemory"
});


// Incluir comentários XML no Swagger
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
if (File.Exists(xmlPath))
c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();


// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente API v1");
});


app.UseHttpsRedirection();


app.MapControllers();


app.Run();