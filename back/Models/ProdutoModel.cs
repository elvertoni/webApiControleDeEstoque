
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estoque.Models
{
	public class ProdutoModel
	{
		// Propriedades do produto
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
		public string? Nome { get; set; }

		[Required(ErrorMessage = "O campo Descrição é obrigatório.")]
		public string? Descricao { get; set; }
		public double Preco { get; set; }

		[Required(ErrorMessage = "O campo Quantidade é obrigatório")]
		public double QuantidadeEstoque { get; set; }

		// Sempre que o objeto for criado, ele instancia
		public DateTime DataValidade { get; set; } = DateTime.Now.AddYears(1);

		// Propriedades relacionadas (sem a obrigatoriedade)
		public int IdFornecedor { get; set; }
		public int? IdCategoria { get; set; }

		// Propriedades de navegação para fornecedor e categoria relacionados
		[ForeignKey("IdFornecedor")]
		public virtual FornecedorModel? Fornecedor { get; set; }

		[ForeignKey("IdCategoria")]
		public virtual CategoriaModel? Categoria { get; set; }

		[ForeignKey("IdFornecedor,IdCategoria")]
		public FornecedorCategoria? FornecedorCategoria { get; set; }
	}
}
