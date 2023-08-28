using System;
using System.Collections.Generic;

namespace ApiClimaAec.Integracao.Response;

public class ClimaPrevisaoResponse
{
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Atualizado_Em { get; set; }
    public List<ClimaResponse> Clima { get; set; }
}
public class ClimaResponse
{
    public DateTime Data { get; set; }
    public string Condicao { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public int Indice_Uv { get; set; }
    public string Condicao_Desc { get; set; }
}