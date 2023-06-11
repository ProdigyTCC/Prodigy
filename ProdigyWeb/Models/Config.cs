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
        public string PorcentagemLucro { get; set; }
        public string TaxaCredito { get; set; }
        public string TaxaDebito { get; set; }
        public string TaxaParcela { get; set; }
        public string PorcentagemDesconto { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<ModuloComposta> ModuloComposta { get; set; }
    }
}