using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace estoque.Models
{
	public class CategoriaModel
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		public string? Nome { get; set; }

		[Required]
		public string? Descricao { get; set; }

		// Propriedade de navegação para os relacionamentos com fornecedores
		public List<CategoriaFornecedor> CategoriaFornecedores { get; set; } = new List<CategoriaFornecedor>();
	}
}
