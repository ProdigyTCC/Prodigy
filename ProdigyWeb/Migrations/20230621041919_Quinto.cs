using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdigyWeb.Migrations
{
    /// <inheritdoc />
    public partial class Quinto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "SFuncionarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "SFuncionarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "SFuncionarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "SFuncionarios",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "SFuncionarios",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "SFuncionarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "SFuncionarios",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "SFuncionarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRepresentante",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRazao",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DataFundacao",
                table: "SFornecedores",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CpfRepresentante",
                table: "SFornecedores",
                type: "character varying(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "SFornecedores",
                type: "character varying(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "SFornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "SFornecedores",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataRegistro",
                table: "SFornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "SFornecedores",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "SFornecedores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "SFornecedores",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "SFornecedores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NfEletronica",
                table: "Configs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SFornecedores_UsuarioId",
                table: "SFornecedores",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_SFornecedores_Usuarios_UsuarioId",
                table: "SFornecedores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SFornecedores_Usuarios_UsuarioId",
                table: "SFornecedores");

            migrationBuilder.DropIndex(
                name: "IX_SFornecedores_UsuarioId",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SFornecedores");

            migrationBuilder.DropColumn(
                name: "NfEletronica",
                table: "Configs");

            migrationBuilder.AlterColumn<string>(
                name: "NomeRepresentante",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NomeRazao",
                table: "SFornecedores",
                type: "integer",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SFornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFundacao",
                table: "SFornecedores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CpfRepresentante",
                table: "SFornecedores",
                type: "character varying(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "SFornecedores",
                type: "character varying(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18,
                oldNullable: true);
        }
    }
}
