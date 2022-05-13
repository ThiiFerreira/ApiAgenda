using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Models
{
    public class Agenda
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titular { get; set; }

        public virtual List<Contato> Contatos { get; set; }

    }
}
