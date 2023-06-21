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
        public string NomeSistema { get; set; }
        public string Valor { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public virtual List<ModuloComposta> ModuloComposta { get; set; }
    }
}