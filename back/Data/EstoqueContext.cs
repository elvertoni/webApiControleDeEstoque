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
		public DbSet<ProdutoModel> Produtos { get; set; }
		public DbSet<FornecedorCategoria> FornecedorCategorias { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FornecedorCategoria>()
				.HasKey(fc => new { fc.FornecedorId, fc.CategoriaId });

			modelBuilder.Entity<FornecedorCategoria>()
				.HasOne(fc => fc.Fornecedor)
				.WithMany(f => f.FornecedorCategoria)
				.HasForeignKey(fc => fc.FornecedorId);

			modelBuilder.Entity<FornecedorCategoria>()
				.HasOne(fc => fc.Categoria)
				.WithMany(c => c.FornecedorCategoria)
				.HasForeignKey(fc => fc.CategoriaId);
		}
	}
}
