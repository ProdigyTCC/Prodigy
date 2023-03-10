using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(200)]
        [Display(Name = "Descrição do produto")]
        public string DescProduto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public int QuantProduto { get; set; }

        [MaxLength(50)]
        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public string Marca { get; set; }

        [Display(Name = "Data de validade")]
        public DateTime DataValidade { get; set; }
        
        [Display(Name = "Data de entrada do produto")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public DateTime DataEntrada { get; set; }
        
        [Display(Name = "Imagem do produto 1")]
        public string Imagem1 { get; set; }

        [Display(Name = "Imagem do produto 2")]
        public string Imagem2 { get; set; }

        [Display(Name = "Valor de custo")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public decimal ValorInicial { get; set; }

        [Display(Name = "Valor de venda")]
        public decimal ValorFinal { get; set; }
        [NotMapped]

        public virtual List<Venda> Vendas { get; set; }

        [ForeignKey("CategoriaProdutoId")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        public int CategoriaProdutoId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}