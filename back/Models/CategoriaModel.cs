using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estoque.Models
{
	public class CategoriaModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Nome { get; set; }

		[Required]
		public string? Descricao { get; set; }

		// Adicione uma propriedade para armazenar os IDs de fornecedores
		[NotMapped]
		public List<int>? FornecedorIds { get; set; }

		// Use uma coleção direta da entidade associativa
		public List<FornecedorCategoria>? FornecedorCategoria { get; set; }
	}
}
