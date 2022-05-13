using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Data.Dtos.Agenda
{
    public class CreateAgendaDto
    {
        [Required]
        public string Titular { get; set; }
    }
}
