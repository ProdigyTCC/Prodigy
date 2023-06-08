using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProdigyWeb.Models
{
    public class Usuario
    {  
        [Key]
        public int UsuarioId { get; set; }

        [Display(Name = "Nome Completo")]
        [MaxLength(100, ErrorMessage = "O seu nome não pode ultrapassar 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Email válido")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Cargo")]
        public string Nivel { get; set; }

        [Display(Name = "Foto")]
        public string Imagem { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        public string DataRegistro { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Plano")]
        public string Plano { get; set; }

        [Display(Name = "Orientação Sexual")]
        public string Sexo { get; set; }

        [MaxLength(10)]
        [Display(Name = "Raça")]
        public string Raca { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        public virtual List<Pagamento> Pagamentos { get; set; }
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
        public virtual List<ModuloComposta> ModuloComposta { get; set; }
    }
}