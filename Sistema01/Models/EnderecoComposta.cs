using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sistema01.Models
{
    [Keyless]
    public class EnderecoComposta
    {
        [Key]
        public int EnderecoCompostaId { get; set; }

        [ForeignKey("ClienteJuridicoId")]
        public virtual ClienteJuridico ClienteJuridico { get; set; }
        public int ClienteJuridicoId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; } 

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}