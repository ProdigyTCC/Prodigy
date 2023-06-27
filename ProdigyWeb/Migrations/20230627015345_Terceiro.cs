using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdigyWeb.Migrations
{
    /// <inheritdoc />
    public partial class Terceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "SPedidos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SPedidos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "SPedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SPedidos_UsuarioId",
                table: "SPedidos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_SPedidos_Usuarios_UsuarioId",
                table: "SPedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPedidos_Usuarios_UsuarioId",
                table: "SPedidos");

            migrationBuilder.DropIndex(
                name: "IX_SPedidos_UsuarioId",
                table: "SPedidos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "SPedidos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SPedidos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SPedidos");
        }
    }
}
