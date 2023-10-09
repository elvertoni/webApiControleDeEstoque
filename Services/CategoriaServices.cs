using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using System;
using System.Threading.Tasks;
=======
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b

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
<<<<<<< HEAD
=======
				// Carregue todos os fornecedores do banco de dados
				var fornecedores = await _context.Fornecedores.ToListAsync();

				// Filtrar fornecedores com base nos IDs fornecidos
				var fornecedoresSelecionados = fornecedores
					.Where(f => categoria.Fornecedores.Any(cf => cf.Id == f.Id))
					.ToList();

				// Associe os fornecedores à categoria
				categoria.Fornecedores = fornecedoresSelecionados;

>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
				// Adicione a categoria ao contexto
				_context.Categorias.Add(categoria);

				// Salve as alterações no banco de dados
				await _context.SaveChangesAsync();

<<<<<<< HEAD
				// Recupere o ID gerado para a categoria
				var categoriaId = categoria.Id;

				// Verifique se a categoria tem fornecedores associados
				if (categoria.CategoriaFornecedores != null && categoria.CategoriaFornecedores.Any())
				{
					// Itere pelos fornecedores associados à categoria
					foreach (var categoriaFornecedor in categoria.CategoriaFornecedores)
					{
						// Verifique se a combinação CategoriaId e FornecedorId já existe no banco de dados
						var existingCategoriaFornecedor = await _context.CategoriaFornecedor
							.FirstOrDefaultAsync(cf => cf.CategoriaId == categoriaId && cf.FornecedorId == categoriaFornecedor.FornecedorId);

						// Se a combinação não existir, adicione-a
						if (existingCategoriaFornecedor == null)
						{
							_context.CategoriaFornecedor.Add(categoriaFornecedor);
						}
					}

					// Salve as alterações novamente para associar os fornecedores à categoria
					await _context.SaveChangesAsync();
				}

				// Carregue a categoria novamente com os fornecedores associados para incluí-los na resposta
				var categoriaConsultada = await _context.Categorias
					.Include(c => c.CategoriaFornecedores)
					.FirstOrDefaultAsync(c => c.Id == categoriaId);

				if (categoriaConsultada != null)
				{
					categoria = categoriaConsultada;
				}

=======
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
				return new CreatedResult("Categoria adicionada com sucesso.", categoria);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao adicionar categoria: {ex.Message}");
			}
		}

<<<<<<< HEAD

		public async Task<IActionResult> AtualizarCategoria(int categoriaId, CategoriaModel categoria)
		{
			try
			{
				var existingCategoria = await _context.Categorias.FindAsync(categoriaId);
				if (existingCategoria == null)
				{
					return new NotFoundObjectResult("Categoria não encontrada.");
				}

				existingCategoria.Nome = categoria.Nome;
				existingCategoria.Descricao = categoria.Descricao;

				// Limpe a lista de CategoriaFornecedores associada à categoria existente
				existingCategoria.CategoriaFornecedores?.Clear();

				// Associe os fornecedores à categoria usando a lista de CategoriaFornecedores
				categoria.CategoriaFornecedores?.ForEach(cf => existingCategoria.CategoriaFornecedores?.Add(cf));

				_context.Update(existingCategoria);
				await _context.SaveChangesAsync();

				return new OkObjectResult("Categoria atualizada com sucesso.");
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult($"Erro ao atualizar categoria: {ex.Message}");
			}
		}


=======
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
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
<<<<<<< HEAD
				// Use o método Include para carregar os fornecedores associados à categoria
				var categoria = await _context.Categorias
					.Include(c => c.CategoriaFornecedores)
					.FirstOrDefaultAsync(c => c.Id == categoriaId);

=======
				var categoria = await _context.Categorias.FindAsync(categoriaId);
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
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

<<<<<<< HEAD
=======
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

>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
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
<<<<<<< HEAD
=======



>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
	}
}
