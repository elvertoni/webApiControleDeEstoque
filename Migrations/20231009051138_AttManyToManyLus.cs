using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoque.Migrations
{
    public partial class AttManyToManyLus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: false,
                defaultValue: 0);
        }
    }
}
