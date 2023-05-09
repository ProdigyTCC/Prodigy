using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SFornecedor
    {
        [Key]
        public int SFornecedorId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome fantasia")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public int NomeRazao { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        [Required(ErrorMessage = "* E-mail obrigatório")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

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
        public virtual List<SEnderecoComposta> SEnderecoCompostas { get; set; }
    }
}