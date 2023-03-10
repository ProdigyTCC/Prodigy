using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Required(ErrorMessage = "Razão social obrigatório")]
        public string NomeRazao { get; set; }

        [MaxLength(18)]
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string RgMunicipal { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string RgEstadual { get; set; }

        [Display(Name = "Natureza jurídica")]
        public string Natureza { get; set; }

        [Display(Name = "Data de fundação")]
        public DateOnly DataFundacao { get; set; }
        
        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
    }
}