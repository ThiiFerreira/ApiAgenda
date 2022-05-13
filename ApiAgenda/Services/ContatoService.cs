using ApiAgenda.Data;
using ApiAgenda.Data.Dtos.Agenda;
using ApiAgenda.Data.Dtos.Contato;
using ApiAgenda.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Services
{
    public class ContatoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private AgendaService _agendaService;

        public ContatoService(AppDbContext context, IMapper mapper, AgendaService agendaService)
        {
            _context = context;
            _mapper = mapper;
            _agendaService = agendaService;
        }

        public ReadContatoDto AdicionaContato(CreateContatoDto contatoDto, int id_agenda)
        {
            ReadAgendaDto agenda = _agendaService.RecuperaAgendaPorId(id_agenda);
            if (agenda == null) return null;

            Contato contato = _mapper.Map<Contato>(contatoDto);
            contato.AgendaId = agenda.Id;
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return _mapper.Map<ReadContatoDto>(contato);
        }

        public List<ReadContatoDto> RecuperaContatosPorIdAgenda(int? agenda)
        {
            ReadAgendaDto readAgenda = _agendaService.RecuperaAgendaPorId((int)agenda);
            if (readAgenda == null) return null;

            List<Contato> contatos;

            if (agenda == null)
            {
                return null;
            }
            else
            {
                contatos = _context.Contatos.Where(contato => contato.AgendaId == agenda).ToList();
            }

            if (contatos != null)
            {
                List<ReadContatoDto> readDto = _mapper.Map<List<ReadContatoDto>>(contatos);
                return readDto;
            }
            return null;

        }

        public ReadContatoDto RecuperaContatoPorId(int id)
        {
            Contato contato = _context.Contatos.FirstOrDefault(contato => contato.Id == id);
            if (contato != null)
            {
                return _mapper.Map<ReadContatoDto>(contato);
            }
            return null;
        }

        
    }
}
