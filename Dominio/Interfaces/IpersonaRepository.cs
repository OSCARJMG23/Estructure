using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<IEnumerable<Persona>> GetListarEmpleados();
        Task<IEnumerable<Persona>> GetListarEmpleadosVigilantes();
        Task<IEnumerable<Persona>> GetClientesVivanBGA();
        Task<IEnumerable<Persona>> GetEmpleadosVivanbgOPiedecuesta();
        Task<IEnumerable<Persona>> GetClientesMas5AñosAntiguedad();
    }
}