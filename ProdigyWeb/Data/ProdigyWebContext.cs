using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<Contato> Contatos { get; set; }
    }
}