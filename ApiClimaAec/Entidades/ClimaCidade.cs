using System;

namespace ApiClimaAec.Entidades;

public class ClimaCidade
{
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public int TemperaturaMinima { get; set; }
    public int TemperaturaMaxima { get; set; }
    public string Condicao { get; set; }
    public string AtualizadoEm { get; set; }
}