using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAgendaMinhavida.Model;
using MinhaAgendaMinhavida.Repository.Interface;
using MinhaAgendaMinhavida.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaMinhavida.Controllers
{
    [Route("agenda/")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        readonly IAgendaService _agendaService;


        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpPost("criarAgenda")]
        public async Task<IActionResult> CriarAgenda([FromBody] Agenda agenda)
        {
            try
            {
                if (agenda == null)
                {
                    return BadRequest();
                }

                await _agendaService.CriarAgenda(agenda);

                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet("BuscarAgendaPorID")]
        public async Task<IActionResult> BuscaAgendaPorID(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                return Ok(await _agendaService.BuscaAgendaPorID(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("BuscarAgendaPorDesc")]
        public async Task<IActionResult> BuscaAgendaPorDesc(string Desc)
        {
            try
            {
                if (Desc == null)
                {
                    return BadRequest();
                }

                return Ok(await _agendaService.BuscaAgendaPorDesc(Desc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AtualizarAgendaPorID")]
        public async Task<IActionResult> AtualizarAgendaPorID([FromBody] Agenda agenda)
        {
            try
            {
                if (agenda == null)
                {
                    return BadRequest();
                }

                await _agendaService.AtualizarAgendaPorID(agenda);

                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("DeletarAgendaPorID")]
        public async Task<IActionResult> DeletarAgendaPorID(int ID)
        {
            try
            {
                if (ID <= 0)
                {
                    return BadRequest();
                }

                await _agendaService.DeletarAgendaPorID(ID);

                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("BuscarAgendas")]
        public async Task<IActionResult> BuscarAgendas()
        {
            try
            {
                List<Agenda> listaAgendas = new List<Agenda>();
                listaAgendas =  (await _agendaService.BuscarAgendas()).ToList();
                return Ok(listaAgendas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
