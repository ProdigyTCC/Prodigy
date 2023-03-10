using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
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

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("JuridicoId")]
        public virtual Juridico Juridico { get; set; }
        public int JuridicoId { get; set; }
    }
}