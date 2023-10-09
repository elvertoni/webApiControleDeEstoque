using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

		// Remova o [NotMapped]
		// Deixe o Entity Framework Core mapear essa propriedade para uma coluna no banco de dados
		public List<FornecedorModel> Fornecedores { get; set; } = new List<FornecedorModel>();

		// Adicione a propriedade IdFornecedor
		public int? IdFornecedor { get; set; }

		// Propriedade de navegação para os produtos relacionados a esta categoria
		public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();

		// Propriedade de navegação para o fornecedor relacionado a esta categoria
		[ForeignKey("IdFornecedor")]
		public FornecedorModel? Fornecedor { get; set; }
	}
}
