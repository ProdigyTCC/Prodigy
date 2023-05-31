using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProdigyWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    CartaoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroCartao = table.Column<int>(type: "integer", nullable: false),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    NomeTitular = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TipoCartao = table.Column<string>(type: "text", nullable: true),
                    CpfTitular = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CnpjTitular = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    ValidadeCartao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.CartaoId);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancarias",
                columns: table => new
                {
                    ContaBancariaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeTitular = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CpfTitular = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CnpjTitular = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Conta = table.Column<int>(type: "integer", nullable: false),
                    Agencia = table.Column<int>(type: "integer", nullable: false),
                    TipoConta = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CobrancaAuto = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancarias", x => x.ContaBancariaId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeSistema = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    Plano = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloId);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    PixId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comprovante = table.Column<string>(type: "text", nullable: true),
                    QrCodeEstatico = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.PixId);
                });

            migrationBuilder.CreateTable(
                name: "SAgendas",
                columns: table => new
                {
                    SAgendaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAgendas", x => x.SAgendaId);
                });

            migrationBuilder.CreateTable(
                name: "SCaixas",
                columns: table => new
                {
                    SCaixaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorAbertura = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ValorFechamento = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCaixas", x => x.SCaixaId);
                });

            migrationBuilder.CreateTable(
                name: "SCategoriaProdutos",
                columns: table => new
                {
                    SCategoriaProdutoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DescCategoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCategoriaProdutos", x => x.SCategoriaProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "SClientes",
                columns: table => new
                {
                    SClienteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataNacimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SClientes", x => x.SClienteId);
                });

            migrationBuilder.CreateTable(
                name: "SEnderecos",
                columns: table => new
                {
                    SEnderecoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEnderecos", x => x.SEnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "SFornecedores",
                columns: table => new
                {
                    SFornecedorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeRazao = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    CpfRepresentante = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    RgEstadual = table.Column<string>(type: "text", nullable: true),
                    RgMunicipal = table.Column<string>(type: "text", nullable: true),
                    DataFundacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NomeRepresentante = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFornecedores", x => x.SFornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "SFuncionarios",
                columns: table => new
                {
                    SFuncionarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Pis = table.Column<string>(type: "text", nullable: true),
                    Nivel = table.Column<string>(type: "text", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Imagem = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstadoCivil = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Sexo = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Habilitacao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Salario = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QtFilhos = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFuncionarios", x => x.SFuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Nivel = table.Column<string>(type: "text", nullable: true),
                    Imagem = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<string>(type: "text", nullable: false),
                    DataRegistro = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Plano = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    Raca = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Nacionalidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "SAgendaCompostas",
                columns: table => new
                {
                    SAgendaCompostaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgendaId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    SClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAgendaCompostas", x => x.SAgendaCompostaId);
                    table.ForeignKey(
                        name: "FK_SAgendaCompostas_SAgendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "SAgendas",
                        principalColumn: "SAgendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAgendaCompostas_SClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "SClientes",
                        principalColumn: "SClienteId");
                });

            migrationBuilder.CreateTable(
                name: "SClienteJuridicos",
                columns: table => new
                {
                    SClienteJuridicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeRazao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    RgEstadual = table.Column<string>(type: "text", nullable: true),
                    RgMunicipal = table.Column<string>(type: "text", nullable: true),
                    Natureza = table.Column<string>(type: "text", nullable: true),
                    DataFundacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataResgistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    SClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SClienteJuridicos", x => x.SClienteJuridicoId);
                    table.ForeignKey(
                        name: "FK_SClienteJuridicos_SClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "SClientes",
                        principalColumn: "SClienteId");
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tema = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NomeEmpresa = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ConfigId);
                    table.ForeignKey(
                        name: "FK_Configs_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Juridicos",
                columns: table => new
                {
                    JuridicoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeRazao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    RgMunicipal = table.Column<string>(type: "text", nullable: true),
                    RgEstadual = table.Column<string>(type: "text", nullable: true),
                    Natureza = table.Column<string>(type: "text", nullable: true),
                    DataFundacao = table.Column<DateOnly>(type: "date", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juridicos", x => x.JuridicoId);
                    table.ForeignKey(
                        name: "FK_Juridicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPagamento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DataPagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    CartaoId = table.Column<int>(type: "integer", nullable: false),
                    PixId = table.Column<int>(type: "integer", nullable: false),
                    ContaBancariaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "CartaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_ContaBancarias_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContaBancarias",
                        principalColumn: "ContaBancariaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Pix_PixId",
                        column: x => x.PixId,
                        principalTable: "Pix",
                        principalColumn: "PixId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SProdutos",
                columns: table => new
                {
                    SProdutoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DescProduto = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    QuantProduto = table.Column<int>(type: "integer", nullable: false),
                    Marca = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Imagem = table.Column<string>(type: "text", nullable: true),
                    ValorInicial = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoriaProdutoId = table.Column<int>(type: "integer", nullable: true),
                    SCategoriaProdutoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    SFornecedorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SProdutos", x => x.SProdutoId);
                    table.ForeignKey(
                        name: "FK_SProdutos_SCategoriaProdutos_CategoriaProdutoId",
                        column: x => x.CategoriaProdutoId,
                        principalTable: "SCategoriaProdutos",
                        principalColumn: "SCategoriaProdutoId");
                    table.ForeignKey(
                        name: "FK_SProdutos_SFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "SFornecedores",
                        principalColumn: "SFornecedorId");
                    table.ForeignKey(
                        name: "FK_SProdutos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SEnderecoCompostas",
                columns: table => new
                {
                    SEnderecoCompostaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteJuridicoId = table.Column<int>(type: "integer", nullable: true),
                    SClienteJuridicoId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    SClienteId = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    SFornecedorId = table.Column<int>(type: "integer", nullable: false),
                    FuncionarioId = table.Column<int>(type: "integer", nullable: true),
                    SFuncionarioId = table.Column<int>(type: "integer", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: true),
                    SEnderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEnderecoCompostas", x => x.SEnderecoCompostaId);
                    table.ForeignKey(
                        name: "FK_SEnderecoCompostas_SClienteJuridicos_ClienteJuridicoId",
                        column: x => x.ClienteJuridicoId,
                        principalTable: "SClienteJuridicos",
                        principalColumn: "SClienteJuridicoId");
                    table.ForeignKey(
                        name: "FK_SEnderecoCompostas_SClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "SClientes",
                        principalColumn: "SClienteId");
                    table.ForeignKey(
                        name: "FK_SEnderecoCompostas_SEnderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "SEnderecos",
                        principalColumn: "SEnderecoId");
                    table.ForeignKey(
                        name: "FK_SEnderecoCompostas_SFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "SFornecedores",
                        principalColumn: "SFornecedorId");
                    table.ForeignKey(
                        name: "FK_SEnderecoCompostas_SFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "SFuncionarios",
                        principalColumn: "SFuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "ModuloComposta",
                columns: table => new
                {
                    ModuloCompostaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ModuloId = table.Column<int>(type: "integer", nullable: false),
                    ConfigId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloComposta", x => x.ModuloCompostaId);
                    table.ForeignKey(
                        name: "FK_ModuloComposta_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                    table.ForeignKey(
                        name: "FK_ModuloComposta_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "ModuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloComposta_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCompostas",
                columns: table => new
                {
                    UsuarioEnderecoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    JuridicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCompostas", x => x.UsuarioEnderecoId);
                    table.ForeignKey(
                        name: "FK_EnderecoCompostas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoCompostas_Juridicos_JuridicoId",
                        column: x => x.JuridicoId,
                        principalTable: "Juridicos",
                        principalColumn: "JuridicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoCompostas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SPedidos",
                columns: table => new
                {
                    SPedidoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    QuantProduto = table.Column<int>(type: "integer", nullable: false),
                    NotaFiscal = table.Column<string>(type: "text", nullable: true),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    SFornecedorId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: true),
                    SProdutoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPedidos", x => x.SPedidoId);
                    table.ForeignKey(
                        name: "FK_SPedidos_SFornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "SFornecedores",
                        principalColumn: "SFornecedorId");
                    table.ForeignKey(
                        name: "FK_SPedidos_SProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "SProdutos",
                        principalColumn: "SProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "SVendas",
                columns: table => new
                {
                    SVendaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FormaPagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ProdutoId = table.Column<int>(type: "integer", nullable: true),
                    SProdutoId = table.Column<int>(type: "integer", nullable: false),
                    FuncionarioId = table.Column<int>(type: "integer", nullable: true),
                    SFuncionarioId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    SClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SVendas", x => x.SVendaId);
                    table.ForeignKey(
                        name: "FK_SVendas_SClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "SClientes",
                        principalColumn: "SClienteId");
                    table.ForeignKey(
                        name: "FK_SVendas_SFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "SFuncionarios",
                        principalColumn: "SFuncionarioId");
                    table.ForeignKey(
                        name: "FK_SVendas_SProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "SProdutos",
                        principalColumn: "SProdutoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configs_UsuarioId",
                table: "Configs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCompostas_EnderecoId",
                table: "EnderecoCompostas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCompostas_JuridicoId",
                table: "EnderecoCompostas",
                column: "JuridicoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCompostas_UsuarioId",
                table: "EnderecoCompostas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Juridicos_UsuarioId",
                table: "Juridicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloComposta_ConfigId",
                table: "ModuloComposta",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloComposta_ModuloId",
                table: "ModuloComposta",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloComposta_UsuarioId",
                table: "ModuloComposta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CartaoId",
                table: "Pagamentos",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ContaBancariaId",
                table: "Pagamentos",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PixId",
                table: "Pagamentos",
                column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_UsuarioId",
                table: "Pagamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SAgendaCompostas_AgendaId",
                table: "SAgendaCompostas",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_SAgendaCompostas_ClienteId",
                table: "SAgendaCompostas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SClienteJuridicos_ClienteId",
                table: "SClienteJuridicos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SEnderecoCompostas_ClienteId",
                table: "SEnderecoCompostas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SEnderecoCompostas_ClienteJuridicoId",
                table: "SEnderecoCompostas",
                column: "ClienteJuridicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SEnderecoCompostas_EnderecoId",
                table: "SEnderecoCompostas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_SEnderecoCompostas_FornecedorId",
                table: "SEnderecoCompostas",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SEnderecoCompostas_FuncionarioId",
                table: "SEnderecoCompostas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SPedidos_FornecedorId",
                table: "SPedidos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SPedidos_ProdutoId",
                table: "SPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_SProdutos_CategoriaProdutoId",
                table: "SProdutos",
                column: "CategoriaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_SProdutos_FornecedorId",
                table: "SProdutos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SProdutos_UsuarioId",
                table: "SProdutos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SVendas_ClienteId",
                table: "SVendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SVendas_FuncionarioId",
                table: "SVendas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SVendas_ProdutoId",
                table: "SVendas",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoCompostas");

            migrationBuilder.DropTable(
                name: "ModuloComposta");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "SAgendaCompostas");

            migrationBuilder.DropTable(
                name: "SCaixas");

            migrationBuilder.DropTable(
                name: "SEnderecoCompostas");

            migrationBuilder.DropTable(
                name: "SPedidos");

            migrationBuilder.DropTable(
                name: "SVendas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Juridicos");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "ContaBancarias");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "SAgendas");

            migrationBuilder.DropTable(
                name: "SClienteJuridicos");

            migrationBuilder.DropTable(
                name: "SEnderecos");

            migrationBuilder.DropTable(
                name: "SFuncionarios");

            migrationBuilder.DropTable(
                name: "SProdutos");

            migrationBuilder.DropTable(
                name: "SClientes");

            migrationBuilder.DropTable(
                name: "SCategoriaProdutos");

            migrationBuilder.DropTable(
                name: "SFornecedores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
