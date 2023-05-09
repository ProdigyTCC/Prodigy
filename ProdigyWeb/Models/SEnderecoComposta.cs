using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProdigyWeb.Models
{
    public class SEnderecoComposta
    {
        [Key]
        public int SEnderecoCompostaId { get; set; }

        [ForeignKey("ClienteJuridicoId")]
        public virtual SClienteJuridico SClienteJuridico { get; set; }
        public int SClienteJuridicoId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual SCliente SCliente { get; set; }
        public int SClienteId { get; set; } 

        [ForeignKey("FornecedorId")]
        public virtual SFornecedor SFornecedor { get; set; }
        public int SFornecedorId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual SFuncionario SFuncionario { get; set; }
        public int SFuncionarioId { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual SEndereco SEndereco { get; set; }
        public int SEnderecoId { get; set; }
    }
}