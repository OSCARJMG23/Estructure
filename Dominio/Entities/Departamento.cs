using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string? NombreDep { get; set; }

    public int? IdPaiss { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pais? IdPaissNavigation { get; set; }
}
