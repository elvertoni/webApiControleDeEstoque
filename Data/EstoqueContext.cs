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
			// Configurar a relação um-para-muitos entre FornecedorModel e CategoriaModel
			// Configurar a relação um-para-muitos entre FornecedorModel e CategoriaModel
			modelBuilder.Entity<FornecedorModel>()
				.HasMany(f => f.Categorias)
				.WithOne() // Corrija o relacionamento inverso aqui
				.HasForeignKey(c => c.IdFornecedor);


			// Configurar a relação um-para-muitos entre CategoriaModel e ProdutoModel
			modelBuilder.Entity<CategoriaModel>()
				.HasMany(c => c.Produtos)
				.WithOne(p => p.Categoria)
				.HasForeignKey(p => p.IdCategoria);

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
