using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            // Configuración de la entidad
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contrato");

            builder.HasIndex(e => e.IdCliente, "id_cliente");

            builder.HasIndex(e => e.IdEmpleado, "id_empleado");

            builder.HasIndex(e => e.IdEstado, "id_estado");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.FechaContrato).HasColumnName("fecha_contrato");
            builder.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");
            builder.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            builder.Property(e => e.IdEstado).HasColumnName("id_estado");

            builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("contrato_ibfk_1");

            builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("contrato_ibfk_2");

            builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("contrato_ibfk_3");

            builder.HasData(
                new Contrato{Id = 1, IdCliente = 2, FechaContrato = new DateOnly(2009, 1, 11), IdEmpleado = 1, FechaFin = new DateOnly(2023, 1, 11), IdEstado = 1},
                new Contrato{Id = 2, IdCliente = 4, FechaContrato = new DateOnly(2022, 2, 11), IdEmpleado = 3, FechaFin = new DateOnly(2023, 2, 11), IdEstado = 1},
                new Contrato{Id = 3, IdCliente = 6, FechaContrato = new DateOnly(2022, 3, 11), IdEmpleado = 5, FechaFin = new DateOnly(2023, 3, 11), IdEstado = 2},
                new Contrato{Id = 4, IdCliente = 8, FechaContrato = new DateOnly(2022, 4, 11), IdEmpleado = 7, FechaFin = new DateOnly(2023, 4, 11), IdEstado = 1},
                new Contrato{Id = 5, IdCliente = 10, FechaContrato = new DateOnly(2022, 5, 11), IdEmpleado = 9, FechaFin = new DateOnly(2023, 5, 11), IdEstado = 3},
                new Contrato{Id = 6, IdCliente = 2, FechaContrato = new DateOnly(2022, 6, 11), IdEmpleado = 11, FechaFin = new DateOnly(2023, 6, 11), IdEstado = 1}
            );
        }
    }
}