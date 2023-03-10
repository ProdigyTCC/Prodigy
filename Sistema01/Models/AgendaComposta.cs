using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class AgendaComposta
    {
        [Key]
        public int AgendaCompostaId { get; set; }

        [ForeignKey("AgendaId")]
        public virtual Agenda Agenda { get; set; }
        public int AgendaId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}