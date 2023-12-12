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
    public class CiudadController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var Ciudad = await _unitOfWork.Ciudads.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(Ciudad);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);
            return _mapper.Map<CiudadDto>(Ciudad);
        }

        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CiudadDto>>> Get([FromQuery]Params CiudadParams)
        {
            var Ciudad = await _unitOfWork.Ciudads.GetAllAsync(CiudadParams.PageIndex, CiudadParams.PageSize, CiudadParams.Search);
            var listaCiudadsDto = _mapper.Map<List<CiudadDto>>(Ciudad.registros);
            return new Pager<CiudadDto>(listaCiudadsDto, Ciudad.totalRegistros, CiudadParams.PageIndex, CiudadParams.PageSize, CiudadParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto)
        {
            var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudads.Add(Ciudad);
            await _unitOfWork.SaveAsync();

            if (Ciudad == null)
            {
                return BadRequest();
            }

            Ciudad.Id = Ciudad.Id;
            return CreatedAtAction(nameof(Post), new { id = Ciudad.Id }, Ciudad);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody]CiudadDto CiudadDto)
        {
            if (CiudadDto == null)
            {
                return NotFound();
            }

            var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudads.Update(Ciudad);
            await _unitOfWork.SaveAsync();
            return CiudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Delete(int id)
        {
            var Ciudad = await _unitOfWork.Ciudads.GetByIdAsync(id);

            if (Ciudad == null)
            {
                return NotFound();
            }

            _unitOfWork.Ciudads.Remove(Ciudad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}