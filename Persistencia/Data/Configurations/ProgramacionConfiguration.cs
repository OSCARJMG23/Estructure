using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("programacion");

            builder.HasIndex(e => e.IdContrato, "id_contrato");

            builder.HasIndex(e => e.IdEmpleado, "id_empleado");

            builder.HasIndex(e => e.IdTurno, "id_turno");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.IdContrato).HasColumnName("id_contrato");
            builder.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            builder.Property(e => e.IdTurno).HasColumnName("id_turno");

            builder.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("programacion_ibfk_1");

            builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("programacion_ibfk_3");

            builder.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("programacion_ibfk_2");
        }
    }
}