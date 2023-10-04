using estoque.Models;
using Microsoft.AspNetCore.Mvc;


namespace estoque.Interfaces
{
	public interface IProduto
	{

		Task<IActionResult> AdicionarProduto(ProdutoModel produto);
		Task<IActionResult> RemoverProduto(int produtoId);
		Task<IActionResult> AtualizarPreço(int produtoId, double novoPreço);
		Task<IActionResult> AtualizarQuantidade(int produtoId, double novaQuantidade);
		Task<IActionResult> ObterProdutoPorId(int produtoId);
		Task<IActionResult> ObterTodosProdutos();

	}
}
