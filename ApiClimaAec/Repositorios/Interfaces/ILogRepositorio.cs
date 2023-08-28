using System.Threading.Tasks;
using ApiClimaAec.Entidades;

namespace ApiClimaAec.Repositorios.Interfaces;

public interface ILogRepositorio
{
    Task<Log> Adicionar(Log log);
}