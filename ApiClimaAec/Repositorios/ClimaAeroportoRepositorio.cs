using System.Threading.Tasks;
using ApiClimaAec.Data;
using ApiClimaAec.Entidades;
using ApiClimaAec.Repositorios.Interfaces;

namespace ApiClimaAec.Repositorios;

public class ClimaAeroportoRepositorio : IClimaAeroportoRepositorio
{
    private readonly ClimaDBContext _climaDbContext;
    public ClimaAeroportoRepositorio(ClimaDBContext climaDbContext)
    {
        _climaDbContext = climaDbContext;
    }
    public async Task<ClimaAeroporto> Adicionar(ClimaAeroporto aeroporto)
    {
        await _climaDbContext.Aeroportos.AddAsync(aeroporto);
        await _climaDbContext.SaveChangesAsync();

        return aeroporto;
    }
}