using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b

namespace estoque.Models
{
	public class FornecedorModel
	{
		[Key]
		public int Id { get; set; }

<<<<<<< HEAD
=======
		[Required]
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
		public string? Nome { get; set; }

		public string? Endereco { get; set; }

		public string? Telefone { get; set; }

		public string? CNPJ { get; set; }

		// Propriedade de navegação para as categorias relacionadas a este fornecedor
<<<<<<< HEAD
		public List<CategoriaFornecedor> FornecedorCategorias { get; set; } = new List<CategoriaFornecedor>();
=======
		public List<CategoriaModel> Categorias { get; set; } = new List<CategoriaModel>();

		// Propriedades de navegação para os produtos fornecidos pelo fornecedor
		public List<ProdutoModel> ProdutosFornecidos { get; set; } = new List<ProdutoModel>();
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
	}
}
