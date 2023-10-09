using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoModelParaManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_IdFornecedor",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_IdFornecedor",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaFornecedor",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFornecedor", x => new { x.CategoriaId, x.FornecedorId });
                    table.ForeignKey(
                        name: "FK_CategoriaFornecedor_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaFornecedor_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaFornecedor_FornecedorId",
                table: "CategoriaFornecedor",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "CategoriaFornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaModelId",
                table: "Fornecedores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_CategoriaModelId",
                table: "Fornecedores",
                column: "CategoriaModelId");

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
                name: "FK_Fornecedores_Categorias_CategoriaModelId",
                table: "Fornecedores",
                column: "CategoriaModelId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
