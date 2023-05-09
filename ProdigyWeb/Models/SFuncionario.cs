using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdigyWeb.Models
{
    public class SFuncionario
    {
        [Key]
        public int SFuncionarioId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Nome { get; set; }

        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public string Pis { get; set; }
        public string Nivel { get; set; }

        [Display(Name = "Data de registro")]
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Foto funcionário")]
        public string Imagem { get; set; }

        [Display(Name = "Data de nascimento do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(10)]
        [Display(Name = "Estado cívil do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string EstadoCivil { get; set; }

        [MaxLength(25)]
        [Display(Name = "orientação sexual")]
        [Required(ErrorMessage = "*Campo obrigatório")]
        public string Sexo { get; set; }

        [MaxLength(14)]
        [Display(Name = "CPF do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public string Cpf { get; set; }

        [MaxLength(20)]
        [Display(Name = "Categoria de habilitação")]
        public string Habilitacao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Salário atual do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public decimal Salario { get; set; }

        [Display(Name = "Data de acerto do funcionário")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Quantidade de filhos")]
        [Required(ErrorMessage = "* Campo obrigatório")]
        public int QtFilhos { get; set; }

        [MaxLength(200)]
        [Display(Name = "Observações")]
        public string Observacao { get; set; }
        [NotMapped]
        public virtual List<SVenda> SVendas { get; set; }
        [NotMapped]
        public virtual List<SEnderecoComposta> SEnderecoCompostas { get; set; }
    }
}