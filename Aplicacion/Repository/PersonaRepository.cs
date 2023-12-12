using Dominio.Entities;
using Dominio.Interfaces;
using Aplicacion.Repository;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly ApiContext _context;

        public PersonaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Personas as IQueryable<Persona>;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.Equals(int.Parse(search)));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            return (totalRegistros, registros);
        }

        public async Task<IEnumerable<Persona>> GetListarEmpleados()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado")
            .ToListAsync();

            return empleados;
        }

        public async Task<IEnumerable<Persona>> GetListarEmpleadosVigilantes()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" && e.IdCategoriaNavigation.NombreCategoria.ToLower() == "vigilante")
            .ToListAsync();

            return empleados;
        }

        public async Task<IEnumerable<Persona>> GetClientesVivanBGA()
        {
            var Clientes = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "cliente"  && e.IdCiudadNavigation.NombreCiudad.ToLower() == "bucaramanga")
            .ToListAsync();

            return Clientes;
        }

        public async Task<IEnumerable<Persona>> GetEmpleadosVivangironOPiedecuesta()
        {
            var empleados = await _context.Personas
            .Where(e=>e.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" 
                && e.IdCiudadNavigation.NombreCiudad.ToLower() == "giron" || e.IdCiudadNavigation.NombreCiudad.ToLower() == "piedecuesta")
            .ToListAsync();

            return empleados;
        }

        public async Task<IEnumerable<Persona>> GetClientesMas5AñosAntiguedad()
        {
            var fechaActual = DateTime.Now;
            
            var Clientes = await _context.Personas
                .Where(e => e.IdTipoPersonaNavigation.Descripcion.ToLower() == "cliente" &&
                            e.DateRegistro.HasValue &&
                            fechaActual.Year - e.DateRegistro.Value.Year > 5)
                .ToListAsync();

            return Clientes;
        }

    }
}