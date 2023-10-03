namespace estoque.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// EstoqueModel.cs
public class EstoqueModel
{

	[Key]
	[Required]
	public int IdProduto { get; set; }

	public double NívelEstoqueMínimo { get; set; }

	public double NívelEstoqueMáximo { get; set; }

	// Propriedade de navegação para o produto relacionado
	public ProdutoModel? Produto { get; set; }
}
