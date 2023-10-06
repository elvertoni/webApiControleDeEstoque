using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class RemovendoEstoqueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedor_FornecedorModelId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Funcionario_FuncionarioModelId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedor_FuncionarioModelId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_FuncionarioModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorModelId",
                table: "Categorias",
                column: "FornecedorModelId",
                principalTable: "Fornecedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Funcionario_FuncionarioModelId",
                table: "Fornecedores",
                column: "FuncionarioModelId",
                principalTable: "Funcionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorModelId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Funcionario_FuncionarioModelId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_FuncionarioModelId",
                table: "Fornecedor",
                newName: "IX_Fornecedor_FuncionarioModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    NívelEstoqueMáximo = table.Column<double>(type: "double", nullable: false),
                    NívelEstoqueMínimo = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Estoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedor_FornecedorModelId",
                table: "Categorias",
                column: "FornecedorModelId",
                principalTable: "Fornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Funcionario_FuncionarioModelId",
                table: "Fornecedor",
                column: "FuncionarioModelId",
                principalTable: "Funcionario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
