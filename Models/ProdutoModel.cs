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
		public int IdFornecedor { get; set; }

		[Required(ErrorMessage = "O campo IdCategoria é obrigatório.")]
		public int IdCategoria { get; set; }

		// Propriedades de navegação para fornecedor e categoria relacionados
		//Esta Com o Virtual do lado pois faz parte do proxy de carregamento lazy
		public virtual FornecedorModel? Fornecedor { get; set; }

		public virtual CategoriaModel? Categoria { get; set; }
	}
}
