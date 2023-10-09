using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estoque.Models
{
	public class FornecedorModel
	{
		[Key]
		public int Id { get; set; }

		public string? Nome { get; set; }

		public string? Endereco { get; set; }

		public string? Telefone { get; set; }

		public string? CNPJ { get; set; }

		// Propriedade de navegação para as categorias relacionadas a este fornecedor
		public List<CategoriaFornecedor> FornecedorCategorias { get; set; } = new List<CategoriaFornecedor>();
	}
}
