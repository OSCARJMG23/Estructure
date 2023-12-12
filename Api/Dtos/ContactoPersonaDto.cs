using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ContactoPersonaDto
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public int? IdPersona { get; set; }

        public int? IdContacto { get; set; }
    }
}