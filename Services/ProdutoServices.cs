using Microsoft.AspNetCore.Mvc;
using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.EntityFrameworkCore;


namespace estoque.Services
{
	public class ProdutoService : IProduto
	{
		private readonly EstoqueContext _context;

		public ProdutoService(EstoqueContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> AdicionarProduto(ProdutoModel produto)
		{
			if (produto == null)
			{
				return new BadRequestObjectResult("Produto inválido.");
			}

			try
			{
				_context.Produtos.Add(produto);
				await _context.SaveChangesAsync();
				return new CreatedResult("Produto adicionado com sucesso.", produto);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao adicionar produto: {ex.Message}");
			}
		}

		public async Task<IActionResult> ObterTodosProdutos()
		{
			try
			{
				var produtos = await _context.Produtos
					.Include(p => p.Categoria) // Inclui Categoria para carregamento preguiçoso
					.Include(p => p.Fornecedor) // Inclui Fornecedor para carregamento preguiçoso
					.ToListAsync();
				return new OkObjectResult(produtos);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao obter produtos: {ex.Message}");
			}
		}

		public async Task<IActionResult> ObterProdutoPorId(int produtoId)
		{
			try
			{
				var produto = await _context.Produtos
					.Include(p => p.Categoria) // Inclui Categoria para carregamento preguiçoso
					.Include(p => p.Fornecedor) // Inclui Fornecedor para carregamento preguiçoso
					.FirstOrDefaultAsync(p => p.Id == produtoId);

				if (produto == null)
				{
					return new NotFoundObjectResult("Produto não encontrado.");
				}

				return new OkObjectResult(produto);
			}
			catch (Exception)
			{
				return new BadRequestObjectResult("Erro ao obter produto.");
			}
		}

		public async Task<IActionResult> AtualizarPreço(int produtoId, double novoPreco)
		{
			try
			{
				var produto = await _context.Produtos.FindAsync(produtoId);
				if (produto == null)
				{
					return new NotFoundObjectResult("Produto não encontrado.");
				}

				produto.Preco = novoPreco;
				await _context.SaveChangesAsync();
				return new OkObjectResult("Preço do produto atualizado com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao atualizar preço: {ex.Message}");
			}
		}

		public async Task<IActionResult> AtualizarQuantidade(int produtoId, double novaQuantidade)
		{
			try
			{
				var produto = await _context.Produtos.FindAsync(produtoId);
				if (produto == null)
				{
					return new NotFoundObjectResult("Produto não encontrado.");
				}

				produto.QuantidadeEstoque = novaQuantidade;
				await _context.SaveChangesAsync();
				return new OkObjectResult("Quantidade do produto atualizada com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao atualizar quantidade: {ex.Message}");
			}
		}

		public async Task<IActionResult> RemoverProduto(int produtoId)
		{
			try
			{
				var produto = await _context.Produtos.FindAsync(produtoId);
				if (produto == null)
				{
					return new NotFoundObjectResult("Produto não encontrado.");
				}

				_context.Produtos.Remove(produto);
				await _context.SaveChangesAsync();
				return new OkObjectResult("Produto removido com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao remover produto: {ex.Message}");
			}
		}
	}
}
