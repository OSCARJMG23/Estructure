using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }

        public string? IdPersona { get; set; }

        public string? Nombre { get; set; }

        public DateOnly? DateRegistro { get; set; }

        public int? IdTipoPersona { get; set; }

        public int? IdCategoria { get; set; }

        public int? IdCiudad { get; set; }
    }
}