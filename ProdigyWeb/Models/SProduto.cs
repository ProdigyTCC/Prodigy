using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SProduto
    {
        [Key]
        public int SProdutoId { get; set; }

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
        public string Marca { get; set; }

        [Display(Name = "Data de validade")]
        public string DataValidade { get; set; }
        
        [Display(Name = "Data de entrada do produto")]
        public string DataEntrada { get; set; }
        
        [Display(Name = "Imagem do produto")]
        public string Imagem { get; set; }

        [Display(Name = "Valor de custo")]
        [Required(ErrorMessage = "*Campo obrigatório!")]
        public string ValorInicial { get; set; }

        [Display(Name = "Valor de venda")]
        public string ValorFinal { get; set; }
        [NotMapped]

        public virtual List<SVenda> SVendas { get; set; }

        [ForeignKey("CategoriaProdutoId")]
        public virtual SCategoriaProduto SCategoriaProduto { get; set; }
        public int SCategoriaProdutoId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual SFornecedor SFornecedor { get; set; }
        public int SFornecedorId { get; set; }
        public virtual List<SPedido> SPedidos { get; set; }
    }
}