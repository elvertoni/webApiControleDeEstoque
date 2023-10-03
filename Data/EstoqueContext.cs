using estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace estoque.Data;

class EstoqueContext : DbContext
{
    public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
    {
    }

    public DbSet<CategoriaModel>? Categoria { get; set; }
    public DbSet<EstoqueModel>? Estoque { get; set; }
    public DbSet<FornecedorModel>? Fornecedor { get; set; }
    public DbSet<FuncionarioModel>? Funcionario { get; set; }
    public DbSet<ProdutoModel>? Produto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar a relação um-para-um entre CategoriaModel e ProdutoModel
        modelBuilder.Entity<CategoriaModel>()
            .HasOne(c => c.Produto)
            .WithOne(p => p.Categoria)
            .HasForeignKey<ProdutoModel>(p => p.IdCategoria);

        // Restante das configurações do modelo

        base.OnModelCreating(modelBuilder);
    }
}
