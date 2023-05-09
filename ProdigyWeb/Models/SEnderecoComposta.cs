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
    public class SEnderecoComposta
    {
        [Key]
        public int EnderecoCompostaId { get; set; }

        [ForeignKey("ClienteJuridicoId")]
        public virtual SClienteJuridico ClienteJuridico { get; set; }
        public int ClienteJuridicoId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual SCliente Cliente { get; set; }
        public int ClienteId { get; set; } 

        [ForeignKey("FornecedorId")]
        public virtual SFornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual SFuncionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual SEndereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}