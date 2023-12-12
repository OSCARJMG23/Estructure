using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class TipoContacto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();
}
