using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ContratoDto
    {
        public int Id { get; set; }

        public DateOnly? FechaContrato { get; set; }

        public DateOnly? FechaFin { get; set; }

        public int? IdCliente { get; set; }

        public int? IdEmpleado { get; set; }

        public int? IdEstado { get; set; }
    }
}