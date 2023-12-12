using Dominio.Entities;
using Dominio.Interfaces;
using Aplicacion.Repository;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository
{
    public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersonaRepository
    {
        private readonly ApiContext _context;

        public ContactoPersonaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<ContactoPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.ContactoPersonas as IQueryable<ContactoPersona>;
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

        public async Task<IEnumerable<object>> GetListarContactoEmpleadoVigilante()
        {
            var contactosVigilantes = await _context.ContactoPersonas
            .Where(e=> e.IdPersonaNavigation.IdTipoPersonaNavigation.Descripcion.ToLower() == "empleado" 
                && e.IdPersonaNavigation.IdCategoriaNavigation.NombreCategoria.ToLower() == "vigilante")
            .Select(e=>new
            {
                Contacto = e.Descripcion
            }).ToListAsync();

            return contactosVigilantes;
        }
    }
}