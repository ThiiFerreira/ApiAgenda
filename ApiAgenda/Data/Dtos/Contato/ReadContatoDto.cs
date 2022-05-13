using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Data.Dtos.Contato
{
    public class ReadContatoDto
    {
        public int Id { get; set; }

        public string NomeDoContato { get; set; }

        public string NumeroTelefone { get; set; }

        public string Email { get; set; }
    }
}
