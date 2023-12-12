using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IContactoPersonaRepository : IGenericRepository<ContactoPersona>
    {
        Task<IEnumerable<object>> GetListarContactoEmpleadoVigilante();
    }
}