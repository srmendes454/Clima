using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiClimaAec.Entidades;
using ApiClimaAec.Integracao.Refit;
using ApiClimaAec.Integracao.Response;
using ApiClimaAec.Interfaces;
using ApiClimaAec.Repositorios.Interfaces;

namespace ApiClimaAec.Services;

public class ClimaService : IClima
{
    public void Dispose()
    {

    }
    #region [ Injecão de Dependência ]

    private readonly IClimaRefit _climaRefit;
    private readonly IClimaCidadeRepositorio _cidadeRepositorio;
    private readonly IClimaAeroportoRepositorio _aeroportoRepositorio;
    private readonly ILogRepositorio _logRepositorio;

    #endregion

    #region [ Construtor ]
    public ClimaService(IClimaRefit climaRefit, IClimaCidadeRepositorio cidadeRepositorio, IClimaAeroportoRepositorio aeroportoRepositorio, ILogRepositorio logRepositorio)
    {
        _climaRefit = climaRefit;
        _cidadeRepositorio = cidadeRepositorio;
        _aeroportoRepositorio = aeroportoRepositorio;
        _logRepositorio = logRepositorio;
    }
    #endregion

    #region [ Métodos Públicos ]
    public async Task<List<LocalidadeResponse>> ObterDadosLocalidades()
    {
        try
        {
            var response = await _climaRefit.ObterDadosLocalidades();
            if (response.IsSuccessStatusCode == false)
            {
                var error = response.Error;
                var log = new Log
                {
                    Mensagem = error.Content,
                    Rota = error.Uri?.AbsolutePath,
                    Metodo = error.HttpMethod.ToString(),
                    StatusCode = error.StatusCode.ToString(),
                };
                await _logRepositorio.Adicionar(log);
            }

            if (response.Content != null && response.IsSuccessStatusCode)
                return response.Content;

            return new List<LocalidadeResponse>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<ClimaCapitalResponse>> ObterDadosClimaCapital()
    {
        try
        {
            var response = await _climaRefit.ObterDadosClimaCapital();
            if (response.IsSuccessStatusCode == false)
            {
                var error = response.Error;
                var log = new Log
                {
                    Mensagem = error.Content,
                    Rota = error.Uri?.AbsolutePath,
                    Metodo = error.HttpMethod.ToString(),
                    StatusCode = error.StatusCode.ToString(),
                };
                await _logRepositorio.Adicionar(log);
            }

            if (response.Content != null && response.IsSuccessStatusCode)
                return response.Content;

            return new List<ClimaCapitalResponse>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<ClimaAeroportoResponse> ObterDadosClimaAeroporto(string icaoCode)
    {
        try
        {
            var response = await _climaRefit.ObterDadosClimaAeroporto(icaoCode);
            if (response.IsSuccessStatusCode == false)
            {
                var error = response.Error;
                var log = new Log
                {
                    Mensagem = error.Content,
                    Rota = error.Uri?.AbsolutePath,
                    Metodo = error.HttpMethod.ToString(),
                    StatusCode = error.StatusCode.ToString(),
                };
                await _logRepositorio.Adicionar(log);
            }

            if (response.Content != null && response.IsSuccessStatusCode)
            {
                var clima = response.Content;
                var model = new ClimaAeroporto
                {
                    Codigo = clima.Codigo_Icao,
                    AtualizadoEm = clima.Atualizado_Em,
                    Condicao = clima.Condicao_Desc,
                    Temperatura = clima.Temp,
                    Vento = clima.Vento
                };

                await _aeroportoRepositorio.Adicionar(model);
                return response.Content;
            }

            return new ClimaAeroportoResponse();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<ClimaPrevisaoResponse> ObterDadosPrevisaoCidade(string cityCode)
    {
        try
        {
            var response = await _climaRefit.ObterDadosPrevisaoCidade(cityCode);
            if (response.IsSuccessStatusCode == false)
            {
                var error = response.Error;
                var log = new Log
                {
                    Mensagem = error.Content,
                    Rota = error.Uri?.AbsolutePath,
                    Metodo = error.HttpMethod.ToString(),
                    StatusCode = error.StatusCode.ToString(),
                };
                await _logRepositorio.Adicionar(log);
            }
            if (response.Content != null && response.IsSuccessStatusCode)
            {
                var clima = response.Content;
                var model = new ClimaCidade
                {
                    Cidade = clima.Cidade,
                    UF = clima.Estado,
                    AtualizadoEm = clima.Atualizado_Em,
                    TemperaturaMaxima = clima.Clima[^1]?.Max ?? 0,
                    TemperaturaMinima = clima.Clima[^1]?.Min ?? 0,
                    Condicao = clima.Clima.Select(x => x.Condicao_Desc).LastOrDefault()
                };

                await _cidadeRepositorio.Adicionar(model);
                return response.Content;
            }

            return new ClimaPrevisaoResponse();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    #endregion
}