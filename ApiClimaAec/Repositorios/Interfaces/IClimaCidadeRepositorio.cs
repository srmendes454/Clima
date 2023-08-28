using System.Threading.Tasks;
using ApiClimaAec.Entidades;

namespace ApiClimaAec.Repositorios.Interfaces;

public interface IClimaCidadeRepositorio
{
    Task<ClimaCidade> Adicionar(ClimaCidade cidade);
}