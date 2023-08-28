using ApiClimaAec.Integracao.Refit;
using ApiClimaAec.Integracao.Response;
using ApiClimaAec.Repositorios.Interfaces;
using ApiClimaAec.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClimaAec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimaController : ControllerBase
    {
        #region [ Injecão de Dependência ]
        
        private readonly IClimaRefit _climaRefit;
        private readonly IClimaCidadeRepositorio _cidadeRepositorio;
        private readonly IClimaAeroportoRepositorio _aeroportoRepositorio;
        private readonly ILogRepositorio _logRepositorio;

        #endregion

        #region [ Construtor ]
        public ClimaController(IClimaRefit climaRefit, IClimaCidadeRepositorio cidadeRepositorio, IClimaAeroportoRepositorio aeroportoRepositorio, ILogRepositorio logRepositorio)
        {
            _climaRefit = climaRefit;
            _cidadeRepositorio = cidadeRepositorio;
            _aeroportoRepositorio = aeroportoRepositorio;
            _logRepositorio = logRepositorio;
        }
        #endregion

        #region [ Rotas ]

        [HttpGet("/localidades")]
        public async Task<ActionResult<List<ClimaCapitalResponse>>> ObterDadosLocalidades()
        {
            var service = new ClimaService(_climaRefit, _cidadeRepositorio, _aeroportoRepositorio, _logRepositorio);
            var response = await service.ObterDadosLocalidades();
            if (!response.Any())
            {
                return BadRequest("Nenhuma localidade encontrada!");
            }
            return Ok(response);
        }

        [HttpGet("/capitais")]
        public async Task<ActionResult<List<ClimaCapitalResponse>>> ObterDadosClimaCapital()
        {
            var service = new ClimaService(_climaRefit, _cidadeRepositorio, _aeroportoRepositorio, _logRepositorio);
            var response = await service.ObterDadosClimaCapital();
            if (!response.Any())
            {
                return BadRequest("Nenhuma cidade encontrada!");
            }
            return Ok(response);
        }

        [HttpGet("/aeroporto/{icaoCode}")]
        public async Task<ActionResult<List<ClimaCapitalResponse>>> ObterDadosClimaAeroporto(string icaoCode)
        {
            var service = new ClimaService(_climaRefit, _cidadeRepositorio, _aeroportoRepositorio, _logRepositorio);
            var response = await service.ObterDadosClimaAeroporto(icaoCode);
            if (response == null)
            {
                return BadRequest("Nenhuma aeroporto foi encontrado com o código informado!");
            }
            return Ok(response);
        }

        [HttpGet("/capital/{cityCode}")]
        public async Task<ActionResult<List<ClimaCapitalResponse>>> ObterDadosClimaCapital(string cityCode)
        {
            var service = new ClimaService(_climaRefit, _cidadeRepositorio, _aeroportoRepositorio, _logRepositorio);
            var response = await service.ObterDadosPrevisaoCidade(cityCode);
            if (response == null)
            {
                return BadRequest("Nenhuma previsão foi encontrada para a cidade informada!");
            }
            return Ok(response);
        }
        #endregion
    }
}
