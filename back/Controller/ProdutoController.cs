using Microsoft.AspNetCore.Mvc;
using estoque.Interfaces;
using estoque.Models;
using estoque.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace estoque.Controllers
{
	[ApiController]
	[Route("Estoque/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProduto _produtoService;
		private readonly EstoqueContext _context;

		public ProdutoController(IProduto produtoService, EstoqueContext context)
		{
			_produtoService = produtoService;
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoModel produto)
		{
			try
			{
				// Verificar se o modelo é válido
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				// Verificar se a categoria existe
				var categoria = await _context.Categorias.FindAsync(produto.IdCategoria);
				if (categoria == null)
				{
					return BadRequest("Categoria não encontrada.");
				}

				// Verificar se o fornecedor está associado à categoria
				var fornecedoresAssociados = await _context.FornecedorCategorias
					.Where(fc => fc.CategoriaId == produto.IdCategoria)
					.Select(fc => fc.Fornecedor)
					.ToListAsync();

				if (!fornecedoresAssociados.Any(f => f?.Id == produto.IdFornecedor))
				{
					return BadRequest("O fornecedor escolhido não está associado à categoria.");
				}

				// Associar o produto à categoria e fornecedor escolhidos
				await _produtoService.AdicionarProduto(produto);

				// Exibir o objeto salvo
				Console.WriteLine("Produto salvo com sucesso");
				Console.WriteLine(JsonConvert.SerializeObject(produto, Formatting.Indented));

				return Ok(produto);
			}
			catch (Exception ex)
			{
				return BadRequest($"Erro ao adicionar produto: {ex.Message}");
			}
		}

		[HttpGet("{produtoId}")]
		public IActionResult ObterProduto(int produtoId)
		{
			var produto = _context.Produtos
				.Include(p => p.Categoria)
				.Include(p => p.Fornecedor)
				.Include(p => p.FornecedorCategoria) // Inclua a entidade FornecedorCategoria
				.FirstOrDefault(p => p.Id == produtoId);

			if (produto == null)
			{
				return NotFound("Produto não encontrado.");
			}

			var produtoJson = new
			{
				produto.Id,
				produto.Nome,
				produto.Descricao,
				produto.Preco,
				produto.QuantidadeEstoque,
				produto.DataValidade,
				Categoria = new { produto.Categoria!.Id, produto.Categoria.Nome },
				Fornecedor = new { produto.Fornecedor!.Id, produto.Fornecedor.Nome },
				FornecedorCategoria = new { produto.FornecedorCategoria?.FornecedorId, produto.FornecedorCategoria?.CategoriaId }
			};

			return Ok(produtoJson);
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
