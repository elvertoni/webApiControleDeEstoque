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

		// Propriedades de navegação para produtos fornecidos pelo fornecedor
		public List<ProdutoModel> ProdutosFornecidos { get; set; } = new List<ProdutoModel>();

		// Propriedades de navegação para categorias fornecidas pelo fornecedor
		public List<CategoriaModel> CategoriasFornecidas { get; set; } = new List<CategoriaModel>();
	}
}
