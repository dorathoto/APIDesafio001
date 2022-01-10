using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDesafio001.Models
{
    /// <summary>
    /// Avaliação Musical
    /// </summary>
    public class Produto
    {
        //key
        public int ProdutoId { get; set; }

        //[ForeignKey("ProdutoCategoria")]
        public int ProdutoCategoriaId { get; set; } //fk   ex: 1 - Celular
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }

       
        public virtual ProdutoCategoria ProdutoCategoria { get; set; }
    }
}
