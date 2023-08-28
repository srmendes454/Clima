using System;
using ApiClimaAec.Data;
using ApiClimaAec.Integracao.Refit;
using ApiClimaAec.Interfaces;
using ApiClimaAec.Repositorios;
using ApiClimaAec.Repositorios.Interfaces;
using ApiClimaAec.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClima, ClimaService>();

builder.Services.AddRefitClient<IClimaRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://brasilapi.com.br/api");
});

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ClimaDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IClimaCidadeRepositorio, ClimaCidadeRepositorio>();
builder.Services.AddScoped<IClimaAeroportoRepositorio, ClimaAeroportoRepositorio>();
builder.Services.AddScoped<ILogRepositorio, LogRepositorio>();
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
