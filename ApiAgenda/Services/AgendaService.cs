using ApiAgenda.Data;
using ApiAgenda.Data.Dtos.Agenda;
using ApiAgenda.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Services
{
    public class AgendaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AgendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAgendaDto AdicionaAgenda(CreateAgendaDto agendaDto)
        {
            Agenda agenda = _mapper.Map<Agenda>(agendaDto);
            _context.Agendas.Add(agenda);
            _context.SaveChanges();
            return _mapper.Map<ReadAgendaDto>(agenda);
        }

        public ReadAgendaDto RecuperaAgendaPorId(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if(agenda != null)
            {
                return _mapper.Map<ReadAgendaDto>(agenda);
            }
            return null;
        }

        public int qtdContatos(int id)
        {
            List < Contato > teste = _context.Contatos.Where(contato => contato.AgendaId == id).ToList();
            return teste.Count;
        }

        public Result AtualizaAgenda(int id, CreateAgendaDto agendaDto)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if (agenda == null)
            {
                return Result.Fail("Agenda não encontrada");
            }
            _mapper.Map(agendaDto, agenda);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaAgenda(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if (agenda == null)
            {
                return Result.Fail("Agenda não encontrada");
            }
            _context.Remove(agenda);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
