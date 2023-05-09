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
        [Required(ErrorMessage ="* Nome completo obrigatório!")]
        [MaxLength(100, ErrorMessage = "O seu nome não pode ultrapassar 100 caracteres.")]
        public string Nome { get; set; }

        [EmailAddress]
        [Display(Name = "Email válido")]
        [Required(ErrorMessage = "* E-mail obrigatório")]
        [MaxLength(100, ErrorMessage = "O seu e-mail não pode ultrapassar 100 caracteres")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Cargo")]
        public string Nivel { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Foto")]
        public string Imagem { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "* Data de nascimento obrigatório")]
        public DateOnly DataNascimento { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DataRegistro { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "* Senha obrigatória")]
        [MaxLength(10, ErrorMessage = "A sua senha não pode ultrapassar 10 caracteres"),
            MinLength(4, ErrorMessage = "A sua senha deve conter pelo menos 5 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Status de Pagamento")]
        public string Status { get; set; }

        [Display(Name = "Orientação Sexual")]
        public string Sexo { get; set; }

        [MaxLength(10)]
        [Display(Name = "Raça")]
        public string Raca { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [NotMapped]
        public virtual List<Pagamento> Pagamentos { get; set; }
        [NotMapped]
        public virtual List<EnderecoComposta> EnderecoCompostas { get; set; }
    }
}