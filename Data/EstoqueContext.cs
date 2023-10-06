using estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace estoque.Data
{
	public class EstoqueContext : DbContext
	{
		public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
		{

		}

		public DbSet<CategoriaModel> Categorias { get; set; }
		public DbSet<FornecedorModel> Fornecedores { get; set; }
		public DbSet<FuncionarioModel> Funcionario { get; set; }
		public DbSet<ProdutoModel> Produtos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configurar a relação um-para-muitos entre CategoriaModel e ProdutoModel
			modelBuilder.Entity<CategoriaModel>()
				.HasMany(c => c.Produtos) // Uma categoria tem muitos produtos
				.WithOne(p => p.Categoria) // Um produto pertence a uma categoria
				.HasForeignKey(p => p.IdCategoria); // Chave estrangeira em ProdutoModel

			// Restante das configurações do modelo

			base.OnModelCreating(modelBuilder);
		}
	}
}
