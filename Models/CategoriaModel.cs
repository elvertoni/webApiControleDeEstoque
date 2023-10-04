using System.ComponentModel.DataAnnotations;



namespace estoque.Models;
public class CategoriaModel
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required]
	public string? Nome { get; set; }

	public string? Descricao { get; set; }

	// Propriedade de navegação para os produtos relacionados a esta categoria
	public ICollection<ProdutoModel>? Produtos { get; set; }
}