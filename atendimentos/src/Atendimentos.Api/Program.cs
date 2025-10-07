using Atendimentos.Application.Services;
using Atendimentos.Domain.Repositories;
using Atendimentos.Infrastructure;
using Atendimentos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connStr = builder.Configuration.GetConnectionString("Default")
    ?? "User Id=system;Password=admin;Data Source=localhost:1521/XEPDB1";

builder.Services.AddDbContext<AtendimentosDbContext>(o =>
    o.UseOracle(connStr));

builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IMesaService, MesaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
