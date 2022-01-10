using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiDesafio001.Models
{
    public class AvaliacaoMusica
    {
        //[Key]
        public Guid AvaliacaoMusicaId { get; set; }
        public Guid MusicaId { get; set; }
        public string Nome { get; set; }
        [Required, MaxLength(100)]
        public int Nota { get; set; }
    }
}
