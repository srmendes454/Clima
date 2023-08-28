using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClimaAec.Integracao.Response;
using Refit;

namespace ApiClimaAec.Integracao.Refit;

public interface IClimaRefit
{
    [Get("/cptec/v1/cidade")]
    Task<ApiResponse<List<LocalidadeResponse>>> ObterDadosLocalidades();

    [Get("/cptec/v1/clima/capital")]
    Task<ApiResponse<List<ClimaCapitalResponse>>> ObterDadosClimaCapital();

    [Get("/cptec/v1/clima/aeroporto/{icaoCode}")]
    Task<ApiResponse<ClimaAeroportoResponse>> ObterDadosClimaAeroporto(string icaoCode);

    [Get("/cptec/v1/clima/previsao/{cityCode}")]
    Task<ApiResponse<ClimaPrevisaoResponse>> ObterDadosPrevisaoCidade(string cityCode);
}