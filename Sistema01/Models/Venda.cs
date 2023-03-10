using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        [Display(Name = "Valor total")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        
        [Display(Name = "Data atual")]
        public DateTime DataVenda{ get; set; }

        [MaxLength(30)]
        [Display(Name = "Forma de pagamento")]
        public string FormaPagamento { get; set; }
        
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}