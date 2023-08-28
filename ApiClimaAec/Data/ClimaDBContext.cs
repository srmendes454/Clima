using ApiClimaAec.AutoMapper;
using ApiClimaAec.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiClimaAec.Data;

public class ClimaDBContext : DbContext
{
    public ClimaDBContext(DbContextOptions<ClimaDBContext> options) : base(options)
    {
    }

    public DbSet<ClimaCidade> Cidades { get; set; }
    public DbSet<ClimaAeroporto> Aeroportos { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClimaCidadeMap());
        modelBuilder.ApplyConfiguration(new ClimaAeroportoMap());
        modelBuilder.ApplyConfiguration(new LogMap());
        base.OnModelCreating(modelBuilder);
    }
}