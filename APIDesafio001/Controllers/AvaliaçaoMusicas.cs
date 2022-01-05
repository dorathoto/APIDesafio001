using ApiDesafio001.Context;
using ApiDesafio001.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafio001.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AvaliaçaoMusicasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AvaliaçaoMusicasController(AppDbContext contexto)
        {
            _context = contexto;

        }

        [HttpGet("musicas")]
        public ActionResult<IEnumerable<AvaliaçaoMusica>> GetCategoriasProdutos()
        {
            return _context.AvaliaçaoMusicas.Include(x => x.Musicas).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<AvaliaçaoMusica>> Get()
        {
            return _context.AvaliaçaoMusicas.AsNoTracking().ToList();
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
        public ActionResult Post([FromBody] AvaliaçaoMusica avaliaçaomusica)
        {
            _context.AvaliaçaoMusicas.Add(avaliaçaomusica);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = avaliaçaomusica.AvaliaçaoMusicaId }, avaliaçaomusica);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AvaliaçaoMusica avaliaçaomusica)
        {          
            if (id != avaliaçaomusica.AvaliaçaoMusicaId)
            {
                return BadRequest();
            }

            _context.Entry(avaliaçaomusica).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<AvaliaçaoMusica> Delete(int id)
        {
            var avaliaçaomusica = _context.AvaliaçaoMusicas.FirstOrDefault(p => p.AvaliaçaoMusicaId == id);
            if (avaliaçaomusica == null)
            {
                return NotFound();
            }
            _context.AvaliaçaoMusicas.Remove(avaliaçaomusica);
            _context.SaveChanges();
            return avaliaçaomusica;
        }
    }
}
