using Dominio.Entities;
using Dominio.Interfaces;
using Aplicacion.Repository;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository
{
    public class ContratoRepository : GenericRepository<Contrato>, IContratoRepository
    {
        private readonly ApiContext _context;

        public ContratoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetContratoEstadoActivo()
        {
            var contratos = await _context.Contratos
            .Where(e=>e.IdEstadoNavigation.Descripcion.ToLower() == "activo")
            .Select(e=>new
            {
                NroContrato = e.Id,
                NombreCliente = e.IdClienteNavigation.Nombre,
                NombreEmpleado = e.IdEmpleadoNavigation.Nombre
            }).ToListAsync();

            return contratos;
        }
    }
}