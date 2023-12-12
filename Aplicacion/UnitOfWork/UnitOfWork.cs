using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiContext _context;
        private ICategoriaPersonaRepository _categoriaPersonas;

        private ICiudadRepository _ciudads;

        private IContactoPersonaRepository _contactoPersonas;

        private IContratoRepository _contratos;

        private IDepartamentoRepository _departamentos;

        private IEstadoRepository _estados;

        private IPaisRepository _paiss;

        private IPersonaRepository _personas;

        private IProgramacionRepository _programacions;

        private ITipoContactoRepository _tipoContactos;

        private ITipoPersonaRepository _tipoPersonas;

        private ITurnoRepository _turnos;
        private IRolRepository _roles;
        private IUserRepository _users;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }
        
        public ICategoriaPersonaRepository CategoriaPersonas
        {
            get
            {
                if (_categoriaPersonas == null)
                {
                    _categoriaPersonas = new CategoriaPersonaRepository(_context);
                }
                return _categoriaPersonas;
            }
        }

        public ICiudadRepository Ciudads
        {
            get
            {
                if (_ciudads == null)
                {
                    _ciudads = new CiudadRepository(_context);
                }
                return _ciudads;
            }
        }

        public IContactoPersonaRepository ContactoPersonas
        {
            get
            {
                if (_contactoPersonas == null)
                {
                    _contactoPersonas = new ContactoPersonaRepository(_context);
                }
                return _contactoPersonas;
            }
        }

    public IContratoRepository Contratos
    {
        get
        {
            if (_contratos == null)
            {
                _contratos = new ContratoRepository(_context);
            }
            return _contratos;
        }
    }

        public IDepartamentoRepository Departamentos
        {
            get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }

        public IEstadoRepository Estados
        {
            get
            {
                if (_estados == null)
                {
                    _estados = new EstadoRepository(_context);
                }
                return _estados;
            }
        }

        public IPaisRepository Paiss
        {
            get
            {
                if (_paiss == null)
                {
                    _paiss = new PaisRepository(_context);
                }
                return _paiss;
            }
        }

        public IPersonaRepository Personas
        {
            get
            {
                if (_personas == null)
                {
                    _personas = new PersonaRepository(_context);
                }
                return _personas;
            }
        }

        public IProgramacionRepository Programacions
        {
            get
            {
                if (_programacions == null)
                {
                    _programacions = new ProgramacionRepository(_context);
                }
                return _programacions;
            }
        }

        public ITipoContactoRepository TipoContactos
        {
            get
            {
                if (_tipoContactos == null)
                {
                    _tipoContactos = new TipoContactoRepository(_context);
                }
                return _tipoContactos;
            }
        }

        public ITipoPersonaRepository TipoPersonas
        {
            get
            {
                if (_tipoPersonas == null)
                {
                    _tipoPersonas = new TipoPersonaRepository(_context);
                }
                return _tipoPersonas;
            }
        }

        public ITurnoRepository Turnos
        {
            get
            {
                if (_turnos == null)
                {
                    _turnos = new TurnoRepository(_context);
                }
                return _turnos;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }
        
         public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}