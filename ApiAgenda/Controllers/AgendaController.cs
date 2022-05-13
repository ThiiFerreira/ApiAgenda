using ApiAgenda.Data.Dtos.Agenda;
using ApiAgenda.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Controllers
{
    [ApiController]
    [Route("/agendas")]
    public class AgendaController : ControllerBase
    {
        private AgendaService _agendaService;

        public AgendaController(AgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpPost]
        public IActionResult AdicionaAgenda([FromBody] CreateAgendaDto agendaDto)
        {
            ReadAgendaDto readDto = _agendaService.AdicionaAgenda(agendaDto);
            return CreatedAtAction(nameof(RecuperaAgendaPorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAgendaPorId(int id)
        {
            ReadAgendaDto readDto = _agendaService.RecuperaAgendaPorId(id);
            if (readDto == null) return NotFound("Agenda não encontrada");
            readDto.qtdContatos = _agendaService.qtdContatos(id);
            return Ok(readDto);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaAgenda(int id, [FromBody] CreateAgendaDto agendaDto) {
            
            Result resultado = _agendaService.AtualizaAgenda(id, agendaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAgenda(int id)
        {
            Result resultado = _agendaService.DeletaAgenda(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
