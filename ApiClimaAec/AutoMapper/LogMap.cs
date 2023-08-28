using ApiClimaAec.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiClimaAec.AutoMapper;

public class LogMap : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Metodo).HasMaxLength(100);
        builder.Property(x => x.Rota).HasMaxLength(100);
        builder.Property(x => x.StatusCode).HasMaxLength(50);
        builder.Property(x => x.Mensagem).HasMaxLength(500);
    }
}