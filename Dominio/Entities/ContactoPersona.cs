using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class ContactoPersona
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? IdPersona { get; set; }

    public int? IdContacto { get; set; }

    public virtual TipoContacto? IdContactoNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
