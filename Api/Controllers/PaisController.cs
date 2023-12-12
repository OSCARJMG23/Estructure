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
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var Pais = await _unitOfWork.Paiss.GetAllAsync();
            return _mapper.Map<List<PaisDto>>(Pais);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var Pais = await _unitOfWork.Paiss.GetByIdAsync(id);
            return _mapper.Map<PaisDto>(Pais);
        }


        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PaisDto>>> Get([FromQuery]Params PaisParams)
        {
            var Pais = await _unitOfWork.Paiss.GetAllAsync(PaisParams.PageIndex, PaisParams.PageSize, PaisParams.Search);
            var listaPaissDto = _mapper.Map<List<PaisDto>>(Pais.registros);
            return new Pager<PaisDto>(listaPaissDto, Pais.totalRegistros, PaisParams.PageIndex, PaisParams.PageSize, PaisParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
        {
            var Pais = _mapper.Map<Pais>(PaisDto);
            _unitOfWork.Paiss.Add(Pais);
            await _unitOfWork.SaveAsync();

            if (Pais == null)
            {
                return BadRequest();
            }

            Pais.Id = Pais.Id;
            return CreatedAtAction(nameof(Post), new { id = Pais.Id }, Pais);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto PaisDto)
        {
            if (PaisDto == null)
            {
                return NotFound();
            }

            var Pais = _mapper.Map<Pais>(PaisDto);
            _unitOfWork.Paiss.Update(Pais);
            await _unitOfWork.SaveAsync();
            return PaisDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Delete(int id)
        {
            var Pais = await _unitOfWork.Paiss.GetByIdAsync(id);

            if (Pais == null)
            {
                return NotFound();
            }

            _unitOfWork.Paiss.Remove(Pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}