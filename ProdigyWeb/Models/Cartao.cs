using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class Cartao
    {
        [Key]
        public int CartaoId { get; set; }

        [Display(Name = "Número do cartão")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public int NumeroCartao { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do Titular")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string NomeTitular { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF do titular")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string CpfTitular { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ do titular")]
        public string CnpjTitular { get; set; }
        
        [Display(Name = "Data de Validade")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public DateOnly ValidadeCartao { get; set; }
        [NotMapped]
        public virtual List<Pagamento> Pagamentos { get; set; }
    }
}