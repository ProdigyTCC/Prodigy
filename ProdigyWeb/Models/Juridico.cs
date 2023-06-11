using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
{
    public class Juridico
    {
        [Key]
        public int JuridicoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome Fantasia")]
        public string NomeRazao { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string RgMunicipal { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string RgEstadual { get; set; }

        [Display(Name = "Natureza jurídica")]
        public string Natureza { get; set; }

        [Display(Name = "Data de fundação")]
        public string DataFundacao { get; set; }

        [Display(Name = "Certificado Digital")]
        public string CertificadoNF { get; set; }

        [MaxLength(100)]
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string Rua { get; set; }

        [Display(Name = "N°")]
        public int Numero { get; set; }

        [MaxLength(50)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [MaxLength(50)]
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string Bairro { get; set; }

        [Display(Name = "Número CEP")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string Cep { get; set; }

        [MaxLength(2)]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string Estado { get; set; }

        [MaxLength(50)]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cidade { get; set; }

        [MaxLength(50)]
        [Display(Name = "País")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Pais { get; set; }
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}