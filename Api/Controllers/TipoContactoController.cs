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
    public class TipoContactoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetAllAsync();
            return _mapper.Map<List<TipoContactoDto>>(TipoContacto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDto>> Get(int id)
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);
            return _mapper.Map<TipoContactoDto>(TipoContacto);
        }


        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoContactoDto>>> Get([FromQuery]Params TipoContactoParams)
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetAllAsync(TipoContactoParams.PageIndex, TipoContactoParams.PageSize, TipoContactoParams.Search);
            var listaTipoContactosDto = _mapper.Map<List<TipoContactoDto>>(TipoContacto.registros);
            return new Pager<TipoContactoDto>(listaTipoContactosDto, TipoContacto.totalRegistros, TipoContactoParams.PageIndex, TipoContactoParams.PageSize, TipoContactoParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto TipoContactoDto)
        {
            var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
            _unitOfWork.TipoContactos.Add(TipoContacto);
            await _unitOfWork.SaveAsync();

            if (TipoContacto == null)
            {
                return BadRequest();
            }

            TipoContacto.Id = TipoContacto.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoContacto.Id }, TipoContacto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody]TipoContactoDto TipoContactoDto)
        {
            if (TipoContactoDto == null)
            {
                return NotFound();
            }

            var TipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);
            _unitOfWork.TipoContactos.Update(TipoContacto);
            await _unitOfWork.SaveAsync();
            return TipoContactoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContactoDto>> Delete(int id)
        {
            var TipoContacto = await _unitOfWork.TipoContactos.GetByIdAsync(id);

            if (TipoContacto == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoContactos.Remove(TipoContacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}