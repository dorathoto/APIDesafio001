﻿using ApiDesafio001.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDesafio001.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<AvaliaçaoMusica> AvaliaçaoMusicas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
    }
}
