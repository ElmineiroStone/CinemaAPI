using AutoMapper;
using CinemaAPI.Data;
using CinemaAPI.Data.Dtos.Filme;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private CinemaContext _context;
        private IMapper _mapper;

        public FilmeController(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {

                filmes = _context.Filmes.ToList();
                return Ok(filmes);
            }
            else
            {
                 filmes = _context
                .Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
               
            if (filmes != null)
            {
                List<ReadFilmeDto> filmesDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return Ok(filmesDto);
            }
            return NotFound();
        }   

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
