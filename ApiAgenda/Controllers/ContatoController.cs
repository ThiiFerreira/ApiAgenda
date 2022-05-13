using ApiAgenda.Data.Dtos.Contato;
using ApiAgenda.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Controllers
{
    [ApiController]
    [Route("/contatos")]
    public class ContatoController : ControllerBase
    {
        private ContatoService _contatoService;

        public ContatoController(ContatoService contatoService )
        {
            _contatoService = contatoService;
        }

        
        [HttpPost]
        public IActionResult AdicionaContato([FromBody] CreateContatoDto contatoDto, int? agenda = null)
        {

            ReadContatoDto readDto = _contatoService.AdicionaContato(contatoDto, (int)agenda);
            if (readDto == null) return NotFound();
            return CreatedAtAction(nameof(RecuperaContatoPorId), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaContatosPorIdAgenda(int? agenda = null)
        {
            List<ReadContatoDto> readDto = _contatoService.RecuperaContatosPorIdAgenda(agenda);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaContatoPorId(int id)
        {
            ReadContatoDto readDto = _contatoService.RecuperaContatoPorId(id);
            if (readDto == null) return NotFound("Contato não encontrada");
            return Ok(readDto);
        }
    }
}
