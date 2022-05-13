using ApiAgenda.Data.Dtos.Agenda;
using ApiAgenda.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<CreateAgendaDto, Agenda>();
            CreateMap<Agenda, ReadAgendaDto>();
        }
    }
}
