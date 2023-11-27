using Microsoft.AspNetCore.Mvc;
using estoque.Interfaces;
using estoque.Models;
using estoque.Data;
using Microsoft.EntityFrameworkCore;



namespace estoque.Controllers
{
	[Route("Estoque/[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoria _categoriaService;
		private readonly EstoqueContext _context;
		private readonly ILogger<CategoriaController> _logger; // Adicione esta linha

		public CategoriaController(ICategoria categoriaService, EstoqueContext context, ILogger<CategoriaController> logger) // Adicione o logger ao construtor
		{
			_categoriaService = categoriaService;
			_context = context;
			_logger = logger; // Inicialize o logger no construtor
		}


		[HttpPost]
		public async Task<IActionResult> CriarCategoria([FromBody] CategoriaModel categoriaModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			using var transaction = _context.Database.BeginTransaction();
			try
			{
				// Verifique se os IDs dos fornecedores são válidos
				if (categoriaModel.FornecedorIds != null && categoriaModel.FornecedorIds.Any())
				{
					var fornecedoresExistentes = await _context.Fornecedores
						.Where(f => categoriaModel.FornecedorIds.Contains(f.Id))
						.ToListAsync();

					if (fornecedoresExistentes.Count != categoriaModel.FornecedorIds.Count)
					{
						// Alguns IDs de fornecedores são inválidos
						return BadRequest(new { Mensagem = "IDs de fornecedores inválidos." });
					}
				}

				// Adicione a categoria ao contexto
				_context.Categorias.Add(categoriaModel);

				// Salve as mudanças no banco de dados
				await _context.SaveChangesAsync();

				// Crie instâncias de FornecedorCategoria associando a nova categoria aos fornecedores
				var fornecedorCategorias = categoriaModel.FornecedorIds?.Select(fornecedorId => new FornecedorCategoria
				{
					FornecedorId = fornecedorId,
					CategoriaId = categoriaModel.Id
				});

				if (fornecedorCategorias != null && fornecedorCategorias.Any())
				{
					// Adicione as instâncias de FornecedorCategoria ao contexto
					_context.FornecedorCategorias.AddRange(fornecedorCategorias);

					// Salve as mudanças no banco de dados
					await _context.SaveChangesAsync();

					// Atualize o campo fornecedorIds da categoria com os IDs fornecidos
					categoriaModel.FornecedorIds = fornecedorCategorias.Select(fc => fc.FornecedorId).ToList();

					// Salve as mudanças no banco de dados novamente para persistir a atualização
					await _context.SaveChangesAsync();
				}

				// Commit da transação
				transaction.Commit();

				return Ok(new { Mensagem = "Categoria criada com sucesso!" });
			}
			catch (Exception ex)
			{
				// Rollback da transação em caso de exceção
				transaction.Rollback();
				return BadRequest(new { Mensagem = $"Erro ao criar categoria: {ex.Message}" });
			}
		}

		[HttpGet("InfosFornecedores/{idCategoria}")]
		public IActionResult ObterInformacoesFornecedores(int idCategoria)
		{
			try
			{
				// Consultar na tabela FornecedorCategoria para obter os IDs dos fornecedores associados a essa categoria
				var fornecedorIds = _context.FornecedorCategorias
					.Where(fc => fc.CategoriaId == idCategoria)
					.Select(fc => fc.FornecedorId)
					.ToList();

				// Carregar um JSON com todos os fornecedores presentes
				var fornecedores = _context.Fornecedores
					.Where(f => fornecedorIds.Contains(f.Id))
					.Select(f => new
					{
						Id = f.Id,
						Nome = f.Nome,
						Cnpj = f.CNPJ
					})
					.ToList();

				return Ok(fornecedores);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Erro ao obter informações de fornecedores: {ex.Message}");
				return StatusCode(500, "Erro interno do servidor");
			}
		}


		[HttpGet("{categoriaId}")]
		public async Task<IActionResult> VisualizarCategoria(int categoriaId)
		{
			return await _categoriaService.VisualizarCategoria(categoriaId);
		}

		[HttpGet]
		public async Task<IActionResult> ObterTodasCategorias()
		{
			return await _categoriaService.ObterTodasCategorias();
		}

		[HttpPut("{categoriaId}")]
		public async Task<IActionResult> AtualizarCategoria(int categoriaId, [FromBody] CategoriaModel categoria)
		{
			return await _categoriaService.AtualizarCategoria(categoriaId, categoria);
		}

		[HttpGet]
		[Route("verificarprodutos/{categoriaId}")]
		public async Task<IActionResult> VerificarProdutosDaCategoria(int categoriaId)
		{
			try
			{
				// Verificar se existem produtos associados a esta categoria
				var existemProdutos = await _context.Produtos.AnyAsync(p => p.IdCategoria == categoriaId);

				return Ok(existemProdutos);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro ao verificar produtos da categoria: {ex.Message}");
			}
		}

		[HttpDelete("{categoriaId}")]
		public async Task<IActionResult> RemoverCategoria(int categoriaId)
		{
			return await _categoriaService.RemoverCategoria(categoriaId);
		}
	}
}
