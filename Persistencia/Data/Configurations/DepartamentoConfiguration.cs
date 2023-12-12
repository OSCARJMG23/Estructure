using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("departamento");

            builder.HasIndex(e => e.IdPaiss, "id_Paiss");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdPaiss).HasColumnName("id_Paiss");
            builder.Property(e => e.NombreDep)
                .HasMaxLength(50)
                .HasColumnName("nombre_dep");

            builder.HasOne(d => d.IdPaissNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPaiss)
                .HasConstraintName("departamento_ibfk_1");
                
            builder.HasData(
                new Departamento{Id=1, NombreDep  = "Santander", IdPaiss=1}
            );
        }
    }
}