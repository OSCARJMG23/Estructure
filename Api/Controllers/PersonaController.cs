using Api.Dtos;
using Api.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    
    [Authorize]
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var Persona = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(Persona);
        }


        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonaDto>>> Get([FromQuery]Params PersonaParams)
        {
            var Persona = await _unitOfWork.Personas.GetAllAsync(PersonaParams.PageIndex, PersonaParams.PageSize, PersonaParams.Search);
            var listaPersonasDto = _mapper.Map<List<PersonaDto>>(Persona.registros);
            return new Pager<PersonaDto>(listaPersonasDto, Persona.totalRegistros, PersonaParams.PageIndex, PersonaParams.PageSize, PersonaParams.Search);
        }

        [HttpGet("empleados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetEmpleados()
        {
            var Persona = await _unitOfWork.Personas.GetListarEmpleados();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("empleadosVigilantes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetEmpleadosVigilantes()
        {
            var Persona = await _unitOfWork.Personas.GetListarEmpleadosVigilantes();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("clientesvivanbga")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetClientesVivanBga()
        {
            var Persona = await _unitOfWork.Personas.GetClientesVivanBGA();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("empladosVivanBgaOPiedecuesta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetEmpleadosVivanBgaOPiedecuesta()
        {
            var Persona = await _unitOfWork.Personas.GetEmpleadosVivanbgOPiedecuesta();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("clientesmas5añosantiguedad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetClientesMas5añosAntiguedad()
        {
            var Persona = await _unitOfWork.Personas.GetClientesMas5AñosAntiguedad();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();

            if (Persona == null)
            {
                return BadRequest();
            }

            Persona.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = Persona.Id }, Persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto PersonaDto)
        {
            if (PersonaDto == null)
            {
                return NotFound();
            }

            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);

            if (Persona == null)
            {
                return NotFound();
            }

            _unitOfWork.Personas.Remove(Persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}