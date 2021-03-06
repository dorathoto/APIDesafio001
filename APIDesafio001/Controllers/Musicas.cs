using ApiDesafio001.Context;
using ApiDesafio001.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafio001.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MusicasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MusicasController(AppDbContext contexto)
        {
            _context = contexto;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Musica>> Get()
        {
            return _context.Musicas.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterMusica")]
        public ActionResult<Musica> Get(Guid id)
        {
            var musica = _context.Musicas.AsNoTracking().FirstOrDefault(p => p.MusicaId == id);
            if (musica == null)
            {
                return NotFound();
            }
            return Ok(musica);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Musica musica)
        {
            _context.Musicas.Add(musica);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterMusica",
                new { id = musica.MusicaId }, musica);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Musica musica)
        {
            if (id != musica.MusicaId)
            {
                return BadRequest();
            }

            _context.Entry(musica).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Musica> Delete(Guid id)
        {
            var musica = _context.Musicas.FirstOrDefault(p => p.MusicaId == id);
            if (musica == null)
            {
                return NotFound();
            }
            _context.Musicas.Remove(musica);
            _context.SaveChanges();
            return musica;
        }
    }
}
