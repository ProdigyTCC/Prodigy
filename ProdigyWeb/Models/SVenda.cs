using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SVenda
    {
        [Key]
        public int SVendaId { get; set; }

        [Display(Name = "Valor total")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        
        [Display(Name = "Data atual")]
        public DateTime DataVenda{ get; set; }

        [MaxLength(30)]
        [Display(Name = "Forma de pagamento")]
        public string FormaPagamento { get; set; }
        
        [ForeignKey("ProdutoId")]
        public virtual SProduto SProduto { get; set; }
        public int SProdutoId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual SFuncionario SFuncionario { get; set; }
        public int SFuncionarioId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual SCliente SCliente { get; set; }
        public int SClienteId { get; set; }
    }
}