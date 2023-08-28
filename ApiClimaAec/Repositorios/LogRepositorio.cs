using ApiClimaAec.Data;
using ApiClimaAec.Entidades;
using System.Threading.Tasks;
using ApiClimaAec.Repositorios.Interfaces;

namespace ApiClimaAec.Repositorios;

public class LogRepositorio : ILogRepositorio
{
    private readonly ClimaDBContext _climaDbContext;
    public LogRepositorio(ClimaDBContext climaDbContext)
    {
        _climaDbContext = climaDbContext;
    }
    public async Task<Log> Adicionar(Log log)
    {
        await _climaDbContext.Logs.AddAsync(log);
        await _climaDbContext.SaveChangesAsync();

        return log;
    }
}