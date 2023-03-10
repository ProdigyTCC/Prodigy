using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class EnderecoComposta
    {
        [Key]
        public int UsuarioEnderecoId { get; set; }
        public int EnderecoId { get; set; }
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public int JuridicoId { get; set; }
        [ForeignKey("JuridicoId")]
        public virtual Juridico Juridico { get; set; }
    }
}