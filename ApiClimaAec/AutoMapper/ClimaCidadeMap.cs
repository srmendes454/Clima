using ApiClimaAec.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiClimaAec.AutoMapper;

public class ClimaCidadeMap : IEntityTypeConfiguration<ClimaCidade>
{
    public void Configure(EntityTypeBuilder<ClimaCidade> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(x => x.UF).IsRequired().HasMaxLength(5);
        builder.Property(x => x.Condicao).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TemperaturaMaxima).IsRequired().HasMaxLength(5);
        builder.Property(x => x.TemperaturaMinima).IsRequired().HasMaxLength(5);
        builder.Property(x => x.AtualizadoEm).IsRequired().HasMaxLength(20);
    }
}