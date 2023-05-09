using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SAgendaComposta
    {
        [Key]
        public int SAgendaCompostaId { get; set; }

        [ForeignKey("AgendaId")]
        public virtual SAgenda Agenda { get; set; }
        public int AgendaId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual SCliente SCliente { get; set; }
        public int SClienteId { get; set; }
    }
}