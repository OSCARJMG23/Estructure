using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class PaissConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("Paiss");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.NombrePaiss)
                .HasMaxLength(50)
                .HasColumnName("nombre_Paiss");

            builder.HasData(
                new Pais{Id=1, NombrePaiss  = "Colombia"}
            );
        }
    }
}