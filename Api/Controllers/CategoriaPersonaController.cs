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
    public class CategoriaPersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get()
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetAllAsync();
            return _mapper.Map<List<CategoriaPersonaDto>>(CategoriaPersona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
            return _mapper.Map<CategoriaPersonaDto>(CategoriaPersona);
        }

    
        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CategoriaPersonaDto>>> Get([FromQuery]Params CategoriaPersonaParams)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetAllAsync(CategoriaPersonaParams.PageIndex, CategoriaPersonaParams.PageSize, CategoriaPersonaParams.Search);
            var listaCategoriaPersonasDto = _mapper.Map<List<CategoriaPersonaDto>>(CategoriaPersona.registros);
            return new Pager<CategoriaPersonaDto>(listaCategoriaPersonasDto, CategoriaPersona.totalRegistros, CategoriaPersonaParams.PageIndex, CategoriaPersonaParams.PageSize, CategoriaPersonaParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersona>> Post(CategoriaPersonaDto CategoriaPersonaDto)
        {
            var CategoriaPersona = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Add(CategoriaPersona);
            await _unitOfWork.SaveAsync();

            if (CategoriaPersona == null)
            {
                return BadRequest();
            }

            CategoriaPersona.Id = CategoriaPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaPersona.Id }, CategoriaPersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody]CategoriaPersonaDto CategoriaPersonaDto)
        {
            if (CategoriaPersonaDto == null)
            {
                return NotFound();
            }

            var CategoriaPersona = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Update(CategoriaPersona);
            await _unitOfWork.SaveAsync();
            return CategoriaPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Delete(int id)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);

            if (CategoriaPersona == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoriaPersonas.Remove(CategoriaPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}