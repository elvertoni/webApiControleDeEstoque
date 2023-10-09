using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoModelCategoiaSerialError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaModelId",
                table: "Fornecedores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_CategoriaModelId",
                table: "Fornecedores",
                column: "CategoriaModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaModelId",
                table: "Fornecedores",
                column: "CategoriaModelId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_FornecedorId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Categorias");
        }
    }
}
