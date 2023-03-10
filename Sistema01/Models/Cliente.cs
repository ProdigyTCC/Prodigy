using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sistema01.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Nome { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF do cliente")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Data de registro")]
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public DateTime DataNacimento { get; set; }

        [NotMapped]
        public virtual List<Venda> Vendas { get; set; }
        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
        [NotMapped]
        public virtual List<AgendaComposta> AgendaCompostas { get; set; }
    }
}