using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estoque.Services
{
	public class CategoriaServices : ICategoria
	{
		private readonly EstoqueContext _context;

		public CategoriaServices(EstoqueContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> AdicionarCategoria(CategoriaModel categoria)
		{
			if (categoria == null)
			{
				return new BadRequestObjectResult("Categoria inválida.");
			}

			try
			{
				// Carregue todos os fornecedores do banco de dados
				var fornecedores = await _context.Fornecedores.ToListAsync();

				// Filtrar fornecedores com base nos IDs fornecidos
				var fornecedoresSelecionados = fornecedores
					.Where(f => categoria.Fornecedores.Any(cf => cf.Id == f.Id))
					.ToList();

				// Associe os fornecedores à categoria
				categoria.Fornecedores = fornecedoresSelecionados;

				// Adicione a categoria ao contexto
				_context.Categorias.Add(categoria);

				// Salve as alterações no banco de dados
				await _context.SaveChangesAsync();

				return new CreatedResult("Categoria adicionada com sucesso.", categoria);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao adicionar categoria: {ex.Message}");
			}
		}

		public async Task<IActionResult> RemoverCategoria(int categoriaId)
		{
			try
			{
				var categoria = await _context.Categorias.FindAsync(categoriaId);
				if (categoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				_context.Categorias.Remove(categoria);
				await _context.SaveChangesAsync();
				return new OkObjectResult("Categoria removida com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao remover categoria: {ex.Message}");
			}
		}

		public async Task<IActionResult> VisualizarCategoria(int categoriaId)
		{
			try
			{
				var categoria = await _context.Categorias.FindAsync(categoriaId);
				if (categoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				return new OkObjectResult(categoria);
			}
			catch (Exception)
			{
				return new BadRequestObjectResult("Erro ao visualizar categoria.");
			}
		}

		public async Task<IActionResult> AtualizarCategoria(CategoriaModel categoria)
		{
			try
			{
				var existingCategoria = await _context.Categorias.FindAsync(categoria.Id);
				if (existingCategoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				existingCategoria.Nome = categoria.Nome;
				existingCategoria.Descricao = categoria.Descricao;

				_context.Update(existingCategoria);
				await _context.SaveChangesAsync();

				return new OkObjectResult("Categoria atualizada com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao atualizar categoria: {ex.Message}");
			}
		}

		public async Task<IActionResult> ObterTodasCategorias()
		{
			try
			{
				var categorias = await _context.Categorias.ToListAsync();
				return new OkObjectResult(categorias);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao obter categorias: {ex.Message}");
			}
		}



	}
}
