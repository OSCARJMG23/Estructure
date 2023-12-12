using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("turno");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.HoraTurnoFinal).HasColumnName("hora_turno_final");
            builder.Property(e => e.HoraTurnoInicio).HasColumnName("hora_turno_inicio");
            builder.Property(e => e.NombreTurno)
                .HasMaxLength(50)
                .HasColumnName("nombre_turno");

            builder.HasData(
                new Turno {Id = 1, NombreTurno = "MaÃ±ana", HoraTurnoFinal = 12, HoraTurnoInicio = 6},
                new Turno {Id = 2, NombreTurno = "Tarde", HoraTurnoFinal = 8, HoraTurnoInicio = 12},
                new Turno {Id = 3, NombreTurno = "Noche", HoraTurnoFinal = 12, HoraTurnoInicio = 8}
            );
        }
    }
}