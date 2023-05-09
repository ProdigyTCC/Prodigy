using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema01.Models
{
    public class SEndereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Rua { get; set; }

        [Display(Name = "N°")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public int Numero { get; set; }

        [MaxLength(50)]
        [Display(Name = "Complemento")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Complemento { get; set; }

        [MaxLength(100)]
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public int Cep { get; set; }

        [MaxLength(2)]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "* Campo obirgatório")]
        public string Estado { get; set; }

        [MaxLength(100)]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cidade { get; set; }

        [MaxLength(50)]
        [Display(Name = "País")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Pais { get; set; }
        [NotMapped]
        public virtual List<SEnderecoComposta> EnderecoCompostas { get; set; }
    }
}