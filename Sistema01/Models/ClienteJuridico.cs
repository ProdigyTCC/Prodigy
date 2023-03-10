using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sistema01.Models
{
    public class ClienteJuridico
    {
        [Key]
        public int ClienteJuridicoId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome fantasia")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string NomeRazao { get; set; }
        
        [MaxLength(18)]
        [Display(Name = "CNPJ do cliente")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição estadual")]
        public string RgEstadual { get; set; }

        [Display(Name = "Incrição municipal")]
        public string RgMunicipal { get; set; }

        [Display(Name = "Natureza jurídica")]
        public string Natureza { get; set; }

        [Display(Name = "Data de fundação")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Data de registro")]
        public DateTime DataResgistro { get; set; }

        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}