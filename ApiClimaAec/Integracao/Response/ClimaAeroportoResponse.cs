using System;

namespace ApiClimaAec.Integracao.Response;

public class ClimaAeroportoResponse
{
    public int Umidade { get; set; }
    public string Visibilidade { get; set; }
    public string Codigo_Icao { get; set; }
    public int Pressao_Atmosferica { get; set; }
    public int Vento { get; set; }
    public int Direcao_Vento { get; set; }
    public string Condicao { get; set; }
    public string Condicao_Desc { get; set; }
    public decimal Temp { get; set; }
    public DateTime Atualizado_Em { get; set; }
}