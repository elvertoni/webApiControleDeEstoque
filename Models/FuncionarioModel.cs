// FuncionarioModel.cs
namespace estoque.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class FuncionarioModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    public string? Cargo { get; set; }

    [Required]
    public string? Login { get; set; }

    public bool Logado { get; set; }

    [Required]
    public string? Senha { get; set; }

    // Propriedades de navegação para operações relacionadas
    public List<FornecedorModel>? Fornecedores { get; set; }
    public List<CategoriaModel>? Categorias { get; set; }
    public List<ProdutoModel>? Produtos { get; set; }

    // public void RealizarLogin()
    // {
    //     // Lógica para realizar o login do funcionário
    //     Logado = true;
    // }

    // public void ExecutarOperacaoProduto(IProduto operacaoProduto, ProdutoModel produto)
    // {
    //     // Verificar se o funcionário tem permissão para executar esta operação
    //     if (Logado)
    //     {
    //         // Executar a operação relacionada a Produto
    //         operacaoProduto.AdicionarProduto(produto);
    //     }
    // }

    // public void ExecutarOperacaoCategoria(ICategoria operacaoCategoria, CategoriaModel categoria)
    // {
    //     // Verificar se o funcionário tem permissão para executar esta operação
    //     if (Logado)
    //     {
    //         // Executar a operação relacionada a Categoria
    //         operacaoCategoria.AdicionarCategoria(categoria);
    //     }
    // }

    // public void ExecutarOperacaoFornecedor(IFornecedor operacaoFornecedor, FornecedorModel fornecedor)
    // {
    //     // Verificar se o funcionário tem permissão para executar esta operação
    //     if (Logado)
    //     {
    //         // Executar a operação relacionada a Fornecedor
    //         operacaoFornecedor.AdicionarFornecedor(fornecedor);
    //     }
    // }
}
