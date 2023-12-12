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
    public class DepartamentoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var Departamento = await _unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(Departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            return _mapper.Map<DepartamentoDto>(Departamento);
        }


        [HttpGet("paginado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DepartamentoDto>>> Get([FromQuery]Params DepartamentoParams)
        {
            var Departamento = await _unitOfWork.Departamentos.GetAllAsync(DepartamentoParams.PageIndex, DepartamentoParams.PageSize, DepartamentoParams.Search);
            var listaDepartamentosDto = _mapper.Map<List<DepartamentoDto>>(Departamento.registros);
            return new Pager<DepartamentoDto>(listaDepartamentosDto, Departamento.totalRegistros, DepartamentoParams.PageIndex, DepartamentoParams.PageSize, DepartamentoParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
        {
            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Add(Departamento);
            await _unitOfWork.SaveAsync();

            if (Departamento == null)
            {
                return BadRequest();
            }

            Departamento.Id = Departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = Departamento.Id }, Departamento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto)
        {
            if (DepartamentoDto == null)
            {
                return NotFound();
            }

            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Update(Departamento);
            await _unitOfWork.SaveAsync();
            return DepartamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Delete(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);

            if (Departamento == null)
            {
                return NotFound();
            }

            _unitOfWork.Departamentos.Remove(Departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}