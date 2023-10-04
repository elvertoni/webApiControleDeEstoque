using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoBDCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Fornecedor_FornecedorModelId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Funcionario_FuncionarioModelId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.RenameIndex(
                name: "IX_Categoria_FuncionarioModelId",
                table: "Categorias",
                newName: "IX_Categorias_FuncionarioModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Categoria_FornecedorModelId",
                table: "Categorias",
                newName: "IX_Categorias_FornecedorModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedor_FornecedorModelId",
                table: "Categorias",
                column: "FornecedorModelId",
                principalTable: "Fornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Funcionario_FuncionarioModelId",
                table: "Categorias",
                column: "FuncionarioModelId",
                principalTable: "Funcionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedor_FornecedorModelId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Funcionario_FuncionarioModelId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_FuncionarioModelId",
                table: "Categoria",
                newName: "IX_Categoria_FuncionarioModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_FornecedorModelId",
                table: "Categoria",
                newName: "IX_Categoria_FornecedorModelId");

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Fornecedor_FornecedorModelId",
                table: "Categoria",
                column: "FornecedorModelId",
                principalTable: "Fornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Funcionario_FuncionarioModelId",
                table: "Categoria",
                column: "FuncionarioModelId",
                principalTable: "Funcionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
