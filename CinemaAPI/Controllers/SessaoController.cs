using AutoMapper;
using CinemaAPI.Data;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private CinemaContext _context;
        private IMapper _mapper;

        public SessaoController(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            var sessoes = _context.Sessoes.ToList();
            if (sessoes == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<List<ReadSessaoDto>>(sessoes));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}