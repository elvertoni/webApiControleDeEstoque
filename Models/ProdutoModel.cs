using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estoque.Models
{
	public class ProdutoModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
		public string? Nome { get; set; }

		public string? Descricao { get; set; }

		public double? Preco { get; set; }

		public double? QuantidadeEstoque { get; set; }

		[Required(ErrorMessage = "O campo DataValidade é obrigatório.")]
		public DateTime DataValidade { get; set; }

		[Required(ErrorMessage = "O campo IdFornecedor é obrigatório.")]
		[ForeignKey("FornecedorModel")]
		public int IdFornecedor { get; set; }

		[Required(ErrorMessage = "O campo IdCategoria é obrigatório.")]
		[ForeignKey("CategoriaModel")]
		public int IdCategoria { get; set; }

		// Propriedades de navegação para fornecedor e categoria relacionados
		[Required(ErrorMessage = "O campo Fornecedor é obrigatorio")]
		public FornecedorModel? Fornecedor { get; set; }

		[Required(ErrorMessage = "O campo Categoria é obrigatorio")]
		public CategoriaModel? Categoria { get; set; }
	}
}