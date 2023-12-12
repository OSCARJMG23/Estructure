using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProgramacionDto
    {
        public int Id { get; set; }

        public int? IdContrato { get; set; }

        public int? IdTurno { get; set; }

        public int? IdEmpleado { get; set; }
    }
}