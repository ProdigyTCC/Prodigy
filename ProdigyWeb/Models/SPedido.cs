using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class SPedido
    {
        [Key]
        public int SPedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorPedido { get; set; }
        public int QuantProduto { get; set; }
        public string NotaFiscal { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual SFornecedor SFornecedor { get; set; }
        public int SFornecedorId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual SProduto SProduto { get; set; }
        public int SProdutoId { get; set; }
    }
}