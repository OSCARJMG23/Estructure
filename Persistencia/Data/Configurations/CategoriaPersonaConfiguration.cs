using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
    {
        public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("categoria_persona");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("nombre_categoria");
                
            builder.HasData(
                new CategoriaPersona{Id = 1, NombreCategoria = "Auxiliar"},
                new CategoriaPersona{Id = 2, NombreCategoria = "Cajero"},
                new CategoriaPersona{Id = 3, NombreCategoria = "Supervisor"},
                new CategoriaPersona{Id = 4, NombreCategoria = "Vigilante"}
            );
        }
    }
}