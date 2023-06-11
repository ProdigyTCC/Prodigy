using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdigyWeb.Migrations
{
    /// <inheritdoc />
    public partial class Sexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Configs");

            migrationBuilder.RenameColumn(
                name: "NomeEmpresa",
                table: "Configs",
                newName: "TaxaParcela");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Usuarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartificadoNF",
                table: "Juridicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PorcentagemDesconto",
                table: "Configs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PorcentagemLucro",
                table: "Configs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxaCredito",
                table: "Configs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxaDebito",
                table: "Configs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CartificadoNF",
                table: "Juridicos");

            migrationBuilder.DropColumn(
                name: "PorcentagemDesconto",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "PorcentagemLucro",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "TaxaCredito",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "TaxaDebito",
                table: "Configs");

            migrationBuilder.RenameColumn(
                name: "TaxaParcela",
                table: "Configs",
                newName: "NomeEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Configs",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
