using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estoque.Models
{
	public class CategoriaFornecedor
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Categoria")]
		public int CategoriaId { get; set; }
		public CategoriaModel? Categoria { get; set; }

		[ForeignKey("Fornecedor")]
		public int FornecedorId { get; set; }
		public FornecedorModel? Fornecedor { get; set; }
	}
}
