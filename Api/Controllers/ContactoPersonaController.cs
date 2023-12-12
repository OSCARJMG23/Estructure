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
    public class ContactoPersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetAllAsync();
            return _mapper.Map<List<ContactoPersonaDto>>(ContactoPersona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);
            return _mapper.Map<ContactoPersonaDto>(ContactoPersona);
        }

        
        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ContactoPersonaDto>>> Get([FromQuery]Params ContactoPersonaParams)
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetAllAsync(ContactoPersonaParams.PageIndex, ContactoPersonaParams.PageSize, ContactoPersonaParams.Search);
            var listaContactoPersonasDto = _mapper.Map<List<ContactoPersonaDto>>(ContactoPersona.registros);
            return new Pager<ContactoPersonaDto>(listaContactoPersonasDto, ContactoPersona.totalRegistros, ContactoPersonaParams.PageIndex, ContactoPersonaParams.PageSize, ContactoPersonaParams.Search);
        }

        [HttpGet("empleadosvigilantes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetContactoEmpleadosVigilantes()
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetListarContactoEmpleadoVigilante();
            return Ok(ContactoPersona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersona>> Post(ContactoPersonaDto ContactoPersonaDto)
        {
            var ContactoPersona = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            _unitOfWork.ContactoPersonas.Add(ContactoPersona);
            await _unitOfWork.SaveAsync();

            if (ContactoPersona == null)
            {
                return BadRequest();
            }

            ContactoPersona.Id = ContactoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactoPersona.Id }, ContactoPersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody]ContactoPersonaDto ContactoPersonaDto)
        {
            if (ContactoPersonaDto == null)
            {
                return NotFound();
            }

            var ContactoPersona = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            _unitOfWork.ContactoPersonas.Update(ContactoPersona);
            await _unitOfWork.SaveAsync();
            return ContactoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Delete(int id)
        {
            var ContactoPersona = await _unitOfWork.ContactoPersonas.GetByIdAsync(id);

            if (ContactoPersona == null)
            {
                return NotFound();
            }

            _unitOfWork.ContactoPersonas.Remove(ContactoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}