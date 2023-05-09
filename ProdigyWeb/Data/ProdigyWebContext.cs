using Microsoft.EntityFrameworkCore;
using ProdigyWeb.Models;

namespace ProdigyWeb.Data
{
    public class ProdigyWebContext : DbContext
    {
        public ProdigyWebContext(DbContextOptions<ProdigyWebContext> options)
        : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Juridico> Juridicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<ContaBancaria> ContaBancarias { get; set; }
        public DbSet<Pix> Pix { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<EnderecoComposta> EnderecoCompostas { get; set; }
        //////////////////////////////////////////////////////////////
        public DbSet<SCategoriaProduto> SCategoriaProdutos { get; set; }
        public DbSet<SAgenda> SAgendas { get; set; }
        public DbSet<SAgendaComposta> SAgendaCompostas { get; set; }
        public DbSet<SCliente> SClientes { get; set; }
        public DbSet<SClienteJuridico> SClienteJuridicos { get; set; }
        public DbSet<SEndereco> SEnderecos { get; set; }
        public DbSet<SEnderecoComposta> SEnderecoCompostas { get; set; }
        public DbSet<SFornecedor> SFornecedores { get; set; }
        public DbSet<SFuncionario> SFuncionarios { get; set; }
        public DbSet<SProduto> SProdutos { get; set; }
        public DbSet<SVenda> SVendas { get; set; }
        public DbSet<SPedido> SPedidos { get; set; }
        public DbSet<SCaixa> SCaixas { get; set; }
    }
}