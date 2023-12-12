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
    public class ProgramacionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
        {
            var Programacion = await _unitOfWork.Programacions.GetAllAsync();
            return _mapper.Map<List<ProgramacionDto>>(Programacion);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Get(int id)
        {
            var Programacion = await _unitOfWork.Programacions.GetByIdAsync(id);
            return _mapper.Map<ProgramacionDto>(Programacion);
        }


        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProgramacionDto>>> Get([FromQuery]Params ProgramacionParams)
        {
            var Programacion = await _unitOfWork.Programacions.GetAllAsync(ProgramacionParams.PageIndex, ProgramacionParams.PageSize, ProgramacionParams.Search);
            var listaProgramacionsDto = _mapper.Map<List<ProgramacionDto>>(Programacion.registros);
            return new Pager<ProgramacionDto>(listaProgramacionsDto, Programacion.totalRegistros, ProgramacionParams.PageIndex, ProgramacionParams.PageSize, ProgramacionParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Programacion>> Post(ProgramacionDto ProgramacionDto)
        {
            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programacions.Add(Programacion);
            await _unitOfWork.SaveAsync();

            if (Programacion == null)
            {
                return BadRequest();
            }

            Programacion.Id = Programacion.Id;
            return CreatedAtAction(nameof(Post), new { id = Programacion.Id }, Programacion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody]ProgramacionDto ProgramacionDto)
        {
            if (ProgramacionDto == null)
            {
                return NotFound();
            }

            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programacions.Update(Programacion);
            await _unitOfWork.SaveAsync();
            return ProgramacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Delete(int id)
        {
            var Programacion = await _unitOfWork.Programacions.GetByIdAsync(id);

            if (Programacion == null)
            {
                return NotFound();
            }

            _unitOfWork.Programacions.Remove(Programacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}