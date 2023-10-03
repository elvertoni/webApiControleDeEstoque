
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using estoque.Models;

namespace estoque.Models;

public class ProdutoModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    public string? Descrição { get; set; }

    public double? Preço { get; set; }

    public double? QuantidadeEstoque { get; set; }

    public DateTime DataValidade { get; set; }

    [ForeignKey("FornecedorModel")]
    public int IdFornecedor { get; set; }

    [ForeignKey("CategoriaModel")]
    public int IdCategoria { get; set; }

    // Propriedades de navegação para fornecedor e categoria relacionados
    public FornecedorModel? Fornecedor { get; set; }
    public CategoriaModel? Categoria { get; set; }
}
