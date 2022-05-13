using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Data.Dtos.Agenda
{
    public class ReadAgendaDto
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public int qtdContatos { get; set; }
    }
}
