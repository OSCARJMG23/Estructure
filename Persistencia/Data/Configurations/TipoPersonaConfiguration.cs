using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipo_persona");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");

            builder.HasData(
                new TipoPersona{Id = 1, Descripcion = "Empleado"},
                new TipoPersona{Id = 2, Descripcion = "Cliente"}
            );
        }
    }
}