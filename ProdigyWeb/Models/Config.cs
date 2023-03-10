using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
{
    public class Config
    {
        public int ConfigId { get; set; }

        [MaxLength(20)]
        [Display(Name = "Cor do tema")]
        public string Tema { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}