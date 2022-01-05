using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiDesafio001.Models
{
    public class AvaliacaoMusica
    {
        [Key]
        public int AvaliacaoMusicaId { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        [Required, MaxLength(100)]
        public int Nota { get; set; }
        public Collection<Musica> Musicas { get; set; }
    }
}
