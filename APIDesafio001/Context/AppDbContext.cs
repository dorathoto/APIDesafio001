using ApiDesafio001.Models;
using APIDesafio001.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDesafio001.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<AvaliacaoMusica> AvaliacaoMusicas { get; set; }
        public DbSet<Musica> Musicas { get; set; }



        //testes
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
    }
}
