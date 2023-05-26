using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class Pagamento
    {
       [Key] 
       public int PagamentoId { get; set; } 

       [MaxLength(20)]
       [Display(Name = "Forma de Pagamento")]
       public string TipoPagamento { get; set; } 

       public DateOnly DataPagamento { get; set; } 
       public bool Status { get; set; } 

       [ForeignKey("UsuarioId")]
       public virtual Usuario Usuario { get; set; } 
       public int UsuarioId { get; set; }

       [ForeignKey("CartaoId")]         
       public virtual Cartao Cartao { get; set; } 
       public int CartaoId { get; set; }

       [ForeignKey("PixId")] 
       public virtual Pix Pix { get; set; } 
       public int PixId { get; set; } 

       [ForeignKey("ContaBancariaId")]
       public virtual ContaBancaria ContaBancaria { get; set; } 
       public int ContaBancariaId { get; set; } 
    }
}