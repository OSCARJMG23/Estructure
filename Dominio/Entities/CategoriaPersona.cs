using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class CategoriaPersona
{
    public int Id { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
