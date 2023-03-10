using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
{
    public class Modulo
    {
        [Key]
        public int ModuloId { get; set; }

        [MaxLength(100)]
        public int NomeSistema { get; set; }

        [MaxLength(10)]
        [Display(Name = "Escolha seu plano")]
        [Required(ErrorMessage = "* Campo Obrigatório")]
        public string Plano { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}