using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

            public virtual DbSet<CategoriaPersona> CategoriaPersonas { get; set; }

        public virtual DbSet<Ciudad> Ciudads { get; set; }

        public virtual DbSet<ContactoPersona> ContactoPersonas { get; set; }

        public virtual DbSet<Contrato> Contratos { get; set; }

        public virtual DbSet<Departamento> Departamentos { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Pais> Paiss { get; set; }

        public virtual DbSet<Persona> Personas { get; set; }

        public virtual DbSet<Programacion> Programacions { get; set; }

        public virtual DbSet<TipoContacto> TipoContactos { get; set; }

        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

        public virtual DbSet<Turno> Turnos { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UsersRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}