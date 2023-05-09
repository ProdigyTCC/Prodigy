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

        [Display(Name = "Código do cartão")]
        public int Codigo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do titular")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string NomeTitular { get; set; }

        [Display(Name = "Tipo do cartão")]
        public string TipoCartao { get; set; }

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