using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AtualizandoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorModelId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_FornecedorModelId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FornecedorModelId",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Fornecedores",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Categorias_CategoriaId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_CategoriaId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Fornecedores");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorModelId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_FornecedorModelId",
                table: "Categorias",
                column: "FornecedorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Fornecedores_FornecedorModelId",
                table: "Categorias",
                column: "FornecedorModelId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }
    }
}
