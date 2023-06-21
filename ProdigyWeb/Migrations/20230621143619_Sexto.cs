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
                name: "Plano",
                table: "Modulos");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "SFuncionarios",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeSistema",
                table: "Modulos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Modulos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "Modulos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_UsuarioId",
                table: "Modulos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Usuarios_UsuarioId",
                table: "Modulos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Usuarios_UsuarioId",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_UsuarioId",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "SFuncionarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Modulos");

            migrationBuilder.AlterColumn<int>(
                name: "NomeSistema",
                table: "Modulos",
                type: "integer",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plano",
                table: "Modulos",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
