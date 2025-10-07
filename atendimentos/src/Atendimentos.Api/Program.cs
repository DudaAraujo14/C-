using Atendimentos.Application.Services;
using Atendimentos.Domain.Repositories;
using Atendimentos.Infrastructure.Context;
using Atendimentos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==============================
// 🔧 CONFIGURAÇÃO DO BANCO ORACLE
// ==============================
builder.Services.AddDbContext<AtendimentosDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// ========================================
// 🧩 INJEÇÃO DE DEPENDÊNCIAS (Repositories e Services)
// ========================================

// MESA
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IMesaService, MesaService>();

// GARÇOM
builder.Services.AddScoped<IGarcomRepository, GarcomRepository>();
builder.Services.AddScoped<IGarcomService, GarcomService>();

// ========================================
// 🧱 CONFIGURAÇÃO PADRÃO DO ASP.NET
// ========================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ========================================
// 🚀 CONFIGURAÇÃO DO PIPELINE
// ========================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
