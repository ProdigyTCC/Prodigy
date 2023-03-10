using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class CategoriaProduto
    {
        [Key]
        public int CategoriaProdutoId { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }
    }
}