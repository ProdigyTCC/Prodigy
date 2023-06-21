using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace ProdigyWeb.Models
{
    [Route("[controller]")]
    public class SFuncionario
    {
        [Key]
        public int SFuncionarioId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Pis { get; set; }
        public string Nivel { get; set; }

        [Display(Name = "Data de registro")]
        public string DataRegistro { get; set; }

        [Display(Name = "Foto funcionário")]
        public string Imagem { get; set; }

        [Display(Name = "Data de nascimento do funcionário")]
        public string DataNascimento { get; set; }

        [MaxLength(10)]
        [Display(Name = "Estado cívil do funcionário")]
        public string EstadoCivil { get; set; }

        [MaxLength(25)]
        [Display(Name = "orientação sexual")]
        public string Sexo { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF do funcionário")]
        public string Cpf { get; set; }

        [MaxLength(20)]
        [Display(Name = "Categoria de habilitação")]
        public string Habilitacao { get; set; }

        [Display(Name = "Salário atual do funcionário")]
        public string Salario { get; set; }

        [Display(Name = "Data de acerto do funcionário")]
        public string DataPagamento { get; set; }

        [Display(Name = "Quantidade de filhos")]
        public int QtFilhos { get; set; }

        [MaxLength(200)]
        [Display(Name = "Observações")]
        public string Observacao { get; set; }
        public string Senha { get; set; }

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

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [NotMapped]
        public virtual List<SVenda> SVendas { get; set; }
        [NotMapped]
        public virtual List<SEnderecoComposta> SEnderecoCompostas { get; set; }
    }
}