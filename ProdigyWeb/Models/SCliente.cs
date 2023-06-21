using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProdigyWeb.Models
{
    public class SCliente
    {
        [Key]
        public int SClienteId { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Nome do cliente")]
        public string Nome { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }


        [MaxLength(14)]
        [Display(Name = "CPF do cliente")]
        public string Cpf { get; set; }

        [Display(Name = "Data de registro")]
        public string DataRegistro { get; set; }

        [Display(Name = "Data de nascimento")]
        public string DataNacimento { get; set; }
        public string Sexo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "N°")]
        public string Numero { get; set; }

        [MaxLength(50)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [MaxLength(100)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [MaxLength(2)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [MaxLength(100)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [MaxLength(50)]
        [Display(Name = "País")]
        public string Pais { get; set; }
        
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual List<SVenda> SVendas { get; set; }
        [NotMapped]
        public virtual List<SEnderecoComposta> SEnderecoCompostas { get; set; }
        [NotMapped]
        public virtual List<SAgendaComposta> SAgendaCompostas { get; set; }
    }
}