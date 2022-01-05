using ApiDesafio001.Context;
using ApiDesafio001.Models;
using APIDesafio001.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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




        [HttpGet("{id}", Name = "ObterAvaliaçaoMusica")]
        public ActionResult<AvaliaçaoMusica> Get(int id)
        {
            var avaliaçaomusica = _context.Musicas.AsNoTracking().FirstOrDefault(p => p.AvaliaçaoMusicaId == id);
            if (avaliaçaomusica == null)
            {
                return NotFound();
            }
            return Ok(avaliaçaomusica);
        }

        [HttpPost]
        public ActionResult Post([FromBody] NotasViewModel model)
        {
            var nota = new AvaliaçaoMusica
            {
                AvaliaçaoMusicaId = model.MusicaId,
                Nota = model.Nota
            };


            _context.AvaliaçaoMusicas.Add(nota);
            _context.SaveChanges();

            return Ok("Votado com sucesso");

        }
    }
}
