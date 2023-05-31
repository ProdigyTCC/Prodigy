using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SCategoriaProduto
    {
        [Key]
        public int SCategoriaProdutoId { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }
        
        [MaxLength(50)]
        public string DescCategoria { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}