using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace estoque.Models
{
	public class FornecedorModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Nome { get; set; }

		public string? Endereco { get; set; }

		public string? Telefone { get; set; }

		public string? CNPJ { get; set; }

		// Propriedade de navegação para as categorias relacionadas a este fornecedor
		public List<CategoriaModel> Categorias { get; set; } = new List<CategoriaModel>();

		// Propriedades de navegação para os produtos fornecidos pelo fornecedor
		public List<ProdutoModel> ProdutosFornecidos { get; set; } = new List<ProdutoModel>();
	}
}
