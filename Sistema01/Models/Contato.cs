using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sistema01.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        [Required(ErrorMessage = "* E-mail obrigatório")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Phone]
        [Display(Name = "Telefone residencial")]
        public string Telefone { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        [ForeignKey("ClienteJuridicoId")]
        public virtual ClienteJuridico ClienteJuridico { get; set; }
        public int ClienteJuridicoId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}