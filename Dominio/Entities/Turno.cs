using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Turno
{
    public int Id { get; set; }

    public string? NombreTurno { get; set; }

    public float? HoraTurnoInicio { get; set; }

    public float? HoraTurnoFinal { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
