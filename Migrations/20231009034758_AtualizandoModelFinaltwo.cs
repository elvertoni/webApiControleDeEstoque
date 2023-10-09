using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoModelFinaltwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_FornecedorId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_FornecedorId",
                table: "Categorias",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorId",
                table: "Categorias",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }
    }
}
