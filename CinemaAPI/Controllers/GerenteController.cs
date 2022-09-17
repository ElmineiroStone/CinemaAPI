using AutoMapper;
using CinemaAPI.Data;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private CinemaContext _context;
        private IMapper _mapper;

        public GerenteController(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            var gerentes = _context.Gerentes.ToList();
            if (gerentes == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<List<ReadGerenteDto>>(gerentes));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
