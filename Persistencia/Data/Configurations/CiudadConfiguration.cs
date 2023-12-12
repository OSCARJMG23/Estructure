using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.IdDep, "id_dep");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdDep).HasColumnName("id_dep");
            builder.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .HasColumnName("nombre_ciudad");

            builder.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("ciudad_ibfk_1");

            builder.HasData(
                new Ciudad{Id=1, NombreCiudad  = "Bucaramanga", IdDep = 1},
                new Ciudad{Id=2, NombreCiudad  = "Floridablanca", IdDep = 1},
                new Ciudad{Id=3, NombreCiudad  = "Giron", IdDep = 1},
                new Ciudad{Id=4, NombreCiudad  = "Piedecuesta", IdDep = 1}
            );
        }
    }
}