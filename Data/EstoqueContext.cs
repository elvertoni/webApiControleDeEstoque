using estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace estoque.Data
{
	public class EstoqueContext : DbContext
	{
		public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
		{
		}

		public DbSet<CategoriaModel> Categorias { get; set; } = null!;
		public DbSet<FornecedorModel> Fornecedores { get; set; } = null!;
		public DbSet<FuncionarioModel> Funcionario { get; set; } = null!;
		public DbSet<ProdutoModel> Produtos { get; set; } = null!;
		public DbSet<CategoriaFornecedor> CategoriaFornecedor { get; set; } = null!; // Adicione esta linha


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configurar a relação muitos-para-muitos entre FornecedorModel e CategoriaModel usando CategoriaFornecedor
			modelBuilder.Entity<CategoriaFornecedor>()
				.HasKey(cf => new { cf.CategoriaId, cf.FornecedorId });

			modelBuilder.Entity<CategoriaFornecedor>()
				.HasOne(cf => cf.Categoria)
				.WithMany(c => c.CategoriaFornecedores)
				.HasForeignKey(cf => cf.CategoriaId);

			modelBuilder.Entity<CategoriaFornecedor>()
				.HasOne(cf => cf.Fornecedor)
				.WithMany(f => f.FornecedorCategorias)
				.HasForeignKey(cf => cf.FornecedorId);

			base.OnModelCreating(modelBuilder);
		}

		// Habilitando o modo Lazy para que o carregamento dos relacionamentos seja feito de maneira efetiva.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseLazyLoadingProxies(); // Habilita o Lazy Loading
			}
		}
	}
}
