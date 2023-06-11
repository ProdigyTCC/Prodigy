using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

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

        [MaxLength(20)]
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
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
    }
}