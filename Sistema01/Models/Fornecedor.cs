using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome fantasia")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public int NomeRazao { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ do fornecedor")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cnpj { get; set; }

        [MaxLength(18)]
        [Display(Name = "CPF do representante")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string CpfRepresentante { get; set; }

        [Display(Name = "Inscrição estadual")]
        public string RgEstadual { get; set; }

        [Display(Name = "Inscrição munipal")]
        public string RgMunicipal { get; set; }

        [Display(Name = "Data de fundação")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public DateTime DataFundacao { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do representante")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string NomeRepresentante { get; set; }

        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
    }
}