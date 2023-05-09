using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema01.Models
{
    public class SPedido
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorPedido { get; set; }
        public int QuantProduto { get; set; }
        public string NotaFiscal { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual SFornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual SProduto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}