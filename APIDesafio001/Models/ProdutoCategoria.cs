using System;
using System.Collections;
using System.Collections.Generic;

namespace APIDesafio001.Models
{
    /// <summary>
    /// Musica
    /// </summary>
    public class ProdutoCategoria
    {
        public int ProdutoCategoriaId { get; set; } //pk
        public string Nome { get; set; } //Eletroeletronicos, celulares, TVs


        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
