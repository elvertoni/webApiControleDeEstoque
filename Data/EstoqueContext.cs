using estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace estoque.Data
{
	public class EstoqueContext : DbContext
	{
		public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
		{
		}

<<<<<<< HEAD
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
=======
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
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b

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
