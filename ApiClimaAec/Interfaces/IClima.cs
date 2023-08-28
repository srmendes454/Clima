using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClimaAec.Integracao.Response;

namespace ApiClimaAec.Interfaces;

public interface IClima
{
    Task<List<ClimaCapitalResponse>> ObterDadosClimaCapital();
    Task<ClimaAeroportoResponse> ObterDadosClimaAeroporto(string icaoCode);
    Task<ClimaPrevisaoResponse> ObterDadosPrevisaoCidade(string cityCode);
}