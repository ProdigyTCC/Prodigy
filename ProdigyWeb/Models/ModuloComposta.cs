using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdigyWeb.Models
{
    public class ModuloComposta
    {
        [Key]
        public int ModuloCompostaId{ get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        
        [ForeignKey("ModuloId")]
        public virtual Modulo Modulo { get; set; }
        public int ModuloId { get; set; }
    }
}
