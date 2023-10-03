namespace estoque.Models;

// EstoqueModel.cs
public class EstoqueModel
{
    public int IdProduto { get; set; }

    public double NívelEstoqueMínimo { get; set; }

    public double NívelEstoqueMáximo { get; set; }

    // Propriedade de navegação para o produto relacionado
    public ProdutoModel? Produto { get; set; }
}
