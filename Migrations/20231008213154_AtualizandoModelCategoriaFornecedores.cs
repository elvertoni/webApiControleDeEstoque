using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoModelCategoriaFornecedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_IdFornecedor",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_CategoriaId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdFornecedor",
                table: "Categorias",
                column: "IdFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedores_IdFornecedor",
                table: "Categorias",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_IdFornecedor",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdFornecedor",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Fornecedores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_CategoriaId",
                table: "Fornecedores",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaId",
                table: "Fornecedores",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
