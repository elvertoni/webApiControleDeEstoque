using Microsoft.AspNetCore.Mvc;
using estoque.Interfaces;
using estoque.Models;


namespace estoque.Controllers
{
	[ApiController]
	[Route("Estoque/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProduto _produtoService;

		public ProdutoController(IProduto produtoService)
		{
			_produtoService = produtoService;
		}



		[HttpPost]
		public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoModel produto)
		{
			try
			{
				var resultado = await _produtoService.AdicionarProduto(produto);
				return resultado; // O método AdicionarProduto já retorna um IActionResult
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao adicionar produto: {ex.Message}");
			}
		}




		[HttpGet("{produtoId}")]
		public async Task<IActionResult> ObterProduto(int produtoId)
		{
			try
			{
				var resultado = await _produtoService.ObterProdutoPorId(produtoId);
				return resultado; // O método ObterProdutoPorId já retorna um IActionResult
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao obter produto: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> ObterTodosProdutos()
		{
			try
			{
				var produtos = await _produtoService.ObterTodosProdutos(); // Supondo que você tenha um método ObterTodosProdutos no seu _produtoService
				return produtos; // Retorna todos os produtos em um IActionResult de sucesso (status 200)
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao obter todos os produtos: {ex.Message}");
			}
		}


		[HttpPut("{produtoId}/atualizar-preco")]
		public async Task<IActionResult> AtualizarPreco(int produtoId, [FromBody] double novoPreco)
		{
			try
			{
				var resultado = await _produtoService.AtualizarPreço(produtoId, novoPreco);
				return resultado; // O método AtualizarPreço já retorna um IActionResult
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao atualizar preço: {ex.Message}");
			}
		}

		[HttpPut("{produtoId}/atualizar-quantidade")]
		public async Task<IActionResult> AtualizarQuantidade(int produtoId, [FromBody] double novaQuantidade)
		{
			try
			{
				var resultado = await _produtoService.AtualizarQuantidade(produtoId, novaQuantidade);
				return resultado; // O método AtualizarQuantidade já retorna um IActionResult
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao atualizar quantidade: {ex.Message}");
			}
		}

		[HttpDelete("{produtoId}")]
		public async Task<IActionResult> RemoverProduto(int produtoId)
		{
			try
			{
				var resultado = await _produtoService.RemoverProduto(produtoId);
				return resultado; // O método RemoverProduto já retorna um IActionResult
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao remover produto: {ex.Message}");
			}
		}
	}
}
