using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaPersonaRepository CategoriaPersonas { get; }

        ICiudadRepository Ciudads { get; }

        IContactoPersonaRepository ContactoPersonas { get; }

        IContratoRepository Contratos { get; }

        IDepartamentoRepository Departamentos { get; }

        IEstadoRepository Estados { get; }

        IPaisRepository Paiss { get; }

        IPersonaRepository Personas { get; }

        IProgramacionRepository Programacions { get; }

        ITipoContactoRepository TipoContactos { get; }

        ITipoPersonaRepository TipoPersonas { get; }

        ITurnoRepository Turnos { get; }
        IRolRepository Roles { get; }
        IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
}