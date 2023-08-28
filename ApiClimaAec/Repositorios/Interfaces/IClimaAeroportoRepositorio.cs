using System.Threading.Tasks;
using ApiClimaAec.Entidades;

namespace ApiClimaAec.Repositorios.Interfaces;

public interface IClimaAeroportoRepositorio
{
    Task<ClimaAeroporto> Adicionar(ClimaAeroporto aeroporto);
}