using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class SCaixa
    {
        [Key]
        public int SCaixaId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Valor para abertura de caixa")]
        public decimal ValorAbertura { get; set; }

        [Display(Name = "Valor para fechamento de caixa")]
        public decimal ValorFechamento { get; set; }
    }
}