using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDesafio001.Models
{
    public class Musica
    {
        [Key]
        public Guid MusicaId { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        [Required, MaxLength(100)]
        public string Artista { get; set; }
        [MaxLength(100)]
        public int Ano { get; set; }
        [MaxLength(100)]
        public Guid AvaliaçaoMusicaId { get; set; }
    }
}

