using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema01.Models
{
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Titulo { get; set; }
        public DateTime Data { get; set; }

        [MaxLength(200)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Descricao { get; set; }
        [NotMapped]
        public virtual List<AgendaComposta> AgendaCompostas { get; set; }
    }
}