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
    public class TurnoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
        {
            var Turno = await _unitOfWork.Turnos.GetAllAsync();
            return _mapper.Map<List<TurnoDto>>(Turno);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            return _mapper.Map<TurnoDto>(Turno);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TurnoDto>>> Get([FromQuery]Params TurnoParams)
        {
            var Turno = await _unitOfWork.Turnos.GetAllAsync(TurnoParams.PageIndex, TurnoParams.PageSize, TurnoParams.Search);
            var listaTurnosDto = _mapper.Map<List<TurnoDto>>(Turno.registros);
            return new Pager<TurnoDto>(listaTurnosDto, Turno.totalRegistros, TurnoParams.PageIndex, TurnoParams.PageSize, TurnoParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Turno>> Post(TurnoDto TurnoDto)
        {
            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Add(Turno);
            await _unitOfWork.SaveAsync();

            if (Turno == null)
            {
                return BadRequest();
            }

            Turno.Id = Turno.Id;
            return CreatedAtAction(nameof(Post), new { id = Turno.Id }, Turno);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody]TurnoDto TurnoDto)
        {
            if (TurnoDto == null)
            {
                return NotFound();
            }

            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Update(Turno);
            await _unitOfWork.SaveAsync();
            return TurnoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Delete(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);

            if (Turno == null)
            {
                return NotFound();
            }

            _unitOfWork.Turnos.Remove(Turno);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}