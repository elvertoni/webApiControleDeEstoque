using System.ComponentModel.DataAnnotations;
using estoque.Models;

namespace estoque.Models
{
	public class FornecedorCategoria
	{
		[Key]
		public int FornecedorId { get; set; }

		[Key]
		public int CategoriaId { get; set; }

		public FornecedorModel? Fornecedor { get; set; }
		public CategoriaModel? Categoria { get; set; }


	}
}
