namespace estoque.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using System.Collections.Generic;



public class FornecedorModel
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string? Nome { get; set; }

	public string? Endereço { get; set; }

	public string? Telefone { get; set; }

	public string? CNPJ { get; set; }

	// Lista de produtos fornecidos pelo fornecedor
	public List<ProdutoModel>? ListaDeProdutos { get; set; }

	// Lista de categorias fornecidas pelo fornecedor
	public List<CategoriaModel>? ListaDeCategorias { get; set; }
}
