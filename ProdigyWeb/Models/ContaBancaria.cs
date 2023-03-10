using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class ContaBancaria
    {
        [Key]
        public int ContaBancariaId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do titular")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string NomeTitular { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF do titular")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string CpfTitular { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ do titular")]
        public string CnpjTitular { get; set; }
        
        [Display(Name = "Número da conta")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public int Conta { get; set; }
        
        [Display(Name = "Número da agência")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public int Agencia { get; set; }

        [MaxLength(20)]
        [Display(Name = "Tipo de conta")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string TipoConta { get; set; }

        [Display(Name = "Cobrança automática?")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public bool CobrancaAuto { get; set; }
        
        [NotMapped]
        public virtual List<Pagamento> Pagamentos { get; set; }
    }
}