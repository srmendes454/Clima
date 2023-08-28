using System;

namespace ApiClimaAec.Entidades;

public class ClimaAeroporto
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public int Vento { get; set; }
    public decimal Temperatura { get; set; }
    public string Condicao { get; set; }
    public DateTime AtualizadoEm { get; set; }
}