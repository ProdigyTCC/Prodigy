using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class Pix
    {
        [Key]
        public int PixId { get; set; }
        public string Comprovante { get; set; }
        public string QrCodeEstatico { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        
        [NotMapped]
        public virtual List<Pagamento> Pagamentos { get; set; }
    }
}