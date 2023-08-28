using ApiClimaAec.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiClimaAec.AutoMapper;

public class ClimaAeroportoMap : IEntityTypeConfiguration<ClimaAeroporto>
{
    public void Configure(EntityTypeBuilder<ClimaAeroporto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Codigo).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Condicao).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Temperatura).IsRequired().HasMaxLength(5);
        builder.Property(x => x.AtualizadoEm).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Vento).IsRequired().HasMaxLength(10);
    }
}