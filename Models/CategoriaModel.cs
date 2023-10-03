using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace estoque.Models;
public class CategoriaModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    public string? Descrição { get; set; }

    [ForeignKey("ProdutoModel")]
    public int IdProduto { get; set; }

    // Propriedade de navegação para o produto relacionado
    public ProdutoModel? Produto { get; set; }



}