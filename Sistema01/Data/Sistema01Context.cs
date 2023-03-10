using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema01.Models;

namespace Sistema01.Data
{
    public class Sistema01Context : DbContext
    {
        public Sistema01Context(DbContextOptions<Sistema01Context> options)
        : base(options)
        {}
        
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<AgendaComposta> AgendaCompostas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteJuridico> ClienteJuridicos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoComposta> EnderecoCompostas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}