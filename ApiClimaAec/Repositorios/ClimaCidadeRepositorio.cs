using System.Threading.Tasks;
using ApiClimaAec.Data;
using ApiClimaAec.Entidades;
using ApiClimaAec.Repositorios.Interfaces;

namespace ApiClimaAec.Repositorios;

public class ClimaCidadeRepositorio : IClimaCidadeRepositorio
{
    private readonly ClimaDBContext _climaDbContext;
    public ClimaCidadeRepositorio(ClimaDBContext climaDbContext)
    {
        _climaDbContext = climaDbContext;
    }
    public async Task<ClimaCidade> Adicionar(ClimaCidade cidade)
    {
        await _climaDbContext.Cidades.AddAsync(cidade);
        await _climaDbContext.SaveChangesAsync();

        return cidade;
    }
}