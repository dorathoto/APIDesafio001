using ApiDesafio001.Context;
using ApiDesafio001.Models;
using APIDesafio001.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIDesafio001.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AvaliacaoMusicasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AvaliacaoMusicasController(AppDbContext contexto)
        {
            _context = contexto;

        }

        [HttpGet("{id}", Name = "ObterAvaliacaoMusica")]
        public ActionResult<AvaliacaoMusica> Get(int id)
        {
            var avaliacaomusica = _context.Musicas.AsNoTracking().FirstOrDefault(p => p.AvaliacaoMusicaId == id);
            if (avaliacaomusica == null)
            {
                return NotFound();
            }
            return Ok(avaliacaomusica);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NotasViewModel model)
        {
            var nota = new AvaliacaoMusica
            {
                AvaliacaoMusicaId = model.MusicaId,
                Nota = model.Nota
            };


            _context.AvaliacaoMusicas.Add(nota);
            _context.SaveChanges();

            return Ok("Votado com sucesso");

        }
    }
}
