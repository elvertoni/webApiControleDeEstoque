using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using estoque.Data;
using estoque.Interfaces;
using estoque.Models;


namespace estoque.Services
{
	public class CategoriaServices : ICategoria
	{
		private readonly EstoqueContext _context;

		public CategoriaServices(EstoqueContext context)
		{
			_context = context;
		}



		public async Task<IActionResult> RemoverCategoria(int categoriaId)
		{
			try
			{
				var categoria = await _context.Categorias
					.Include(c => c.FornecedorCategoria)
					.FirstOrDefaultAsync(c => c.Id == categoriaId);
				if (categoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				// Remova as associações FornecedorCategoria
				_context.FornecedorCategorias.RemoveRange(categoria.FornecedorCategoria!);

				_context.Categorias.Remove(categoria);
				await _context.SaveChangesAsync();
				return new OkObjectResult("Categoria removida com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao remover categoria: {ex.Message}");
			}
		}
		[HttpPut("{categoriaId}")]
		public async Task<IActionResult> AtualizarCategoria(int categoriaId, [FromBody] CategoriaModel categoria)
		{
			try
			{
				var existingCategoria = await _context.Categorias
				  .Include(c => c.FornecedorCategoria)
				  .FirstOrDefaultAsync(c => c.Id == categoriaId);

				if (existingCategoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				// Atualize os dados da categoria mesmo que não haja produtos relacionados
				existingCategoria.Nome = categoria.Nome;
				existingCategoria.Descricao = categoria.Descricao;

				// Remova as associações FornecedorCategoria existentes
				_context.FornecedorCategorias.RemoveRange(existingCategoria.FornecedorCategoria!);

				// Atualize as associações FornecedorCategoria apenas se houver pelo menos um fornecedor
				if (categoria.FornecedorIds != null && categoria.FornecedorIds.Any())
				{
					var fornecedores = await _context.Fornecedores
					  .Where(f => categoria.FornecedorIds.Contains(f.Id))
					  .ToListAsync();

					// Crie instâncias de FornecedorCategoria associando a categoria aos fornecedores
					var fornecedorCategorias = fornecedores.Select(fornecedor => new FornecedorCategoria
					{
						Fornecedor = fornecedor,
						Categoria = existingCategoria
					});

					// Adicione as instâncias de FornecedorCategoria ao contexto
					_context.FornecedorCategorias.AddRange(fornecedorCategorias);
				}

				_context.Update(existingCategoria);
				await _context.SaveChangesAsync();

				return new OkObjectResult("Categoria atualizada com sucesso.");
			}
			catch (DbUpdateException)
			{
				// Tratamento de exceção...
				return new ObjectResult($"Não é possível atualizar a categoria. Certifique-se de fornecer o ID da categoria e do fornecedor associados ao produto.")
				{
					StatusCode = 500 // InternalServerError

				};
			}
			catch (Exception ex)
			{
				// Tratamento de exceção...
				return new ObjectResult($"Erro ao atualizar categoria: {ex.Message}")
				{
					StatusCode = 500 // InternalServerError
				};
			}
		}





		public async Task<IActionResult> ObterTodasCategorias()
		{
			try
			{
				var categorias = await _context.Categorias
					.Include(c => c.FornecedorCategoria)
					.ToListAsync();
				return new OkObjectResult(categorias);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao obter categorias: {ex.Message}");
			}
		}

		public async Task<IActionResult> VisualizarCategoria(int categoriaId)
		{
			try
			{
				var categoria = await _context.Categorias
					.Include(c => c.FornecedorCategoria)
					.FirstOrDefaultAsync(c => c.Id == categoriaId);
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
	}
}
