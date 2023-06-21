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
        public string NomeRazao { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ do fornecedor")]
        public string Cnpj { get; set; }

        [MaxLength(18)]
        [Display(Name = "CPF do representante")]
        public string CpfRepresentante { get; set; }

        [Display(Name = "Inscrição estadual")]
        public string RgEstadual { get; set; }

        [Display(Name = "Inscrição munipal")]
        public string RgMunicipal { get; set; }

        [Display(Name = "Data de fundação")]
        public string DataFundacao { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do representante")]
        public string NomeRepresentante { get; set; }

        [Display(Name = "Data de registro")]
        public string DataRegistro { get; set; }

        [MaxLength(100)]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "N°")]
        public string Numero { get; set; }

        [MaxLength(50)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [MaxLength(100)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [MaxLength(2)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [MaxLength(100)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [MaxLength(50)]
        [Display(Name = "País")]
        public string Pais { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual List<SEnderecoComposta> SEnderecoCompostas { get; set; }
    }
}