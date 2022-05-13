using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Models
{
    public class Contato
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeDoContato { get; set; }

        [Required]
        public string NumeroTelefone { get; set; }

        public string Email { get; set; }

        public virtual Agenda Agenda { get; set; }

        public int AgendaId { get; set; }

    }
}
