﻿using System;
using System.Collections.Generic;

namespace Dominio.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public string? IdPersona { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? DateRegistro { get; set; }

    public int? IdTipoPersona { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdCiudad { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();

    public virtual ICollection<Contrato> ContratoIdClienteNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoNavigations { get; set; } = new List<Contrato>();

    public virtual CategoriaPersona? IdCategoriaNavigation { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual TipoPersona? IdTipoPersonaNavigation { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
