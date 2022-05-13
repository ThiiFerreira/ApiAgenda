using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Data.Dtos.Contato
{
    public class CreateContatoDto
    {
        [Required]
        public string NomeDoContato { get; set; }

        [Required]
        public string NumeroTelefone { get; set; }

        public string Email { get; set; }
    }
}
