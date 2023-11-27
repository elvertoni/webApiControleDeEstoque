using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using estoque.Models;

public class FornecedorModel
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string? Nome { get; set; }
	[Required]
	public string? Endereco { get; set; }
	[Required]
	public string? Telefone { get; set; }
	[Required]
	public string? CNPJ { get; set; }

	// Adicione uma propriedade de navegação para as associações FornecedorCategoria
	[JsonIgnore]
	public ICollection<FornecedorCategoria>? FornecedorCategoria { get; set; }


}
