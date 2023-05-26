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
        public DateOnly DataFundacao { get; set; }

        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}