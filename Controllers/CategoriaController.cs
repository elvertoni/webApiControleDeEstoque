using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace estoque.Controllers
{
	[Route("Estoque/[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoria _categoriaService;

		public CategoriaController(ICategoria categoriaService)
		{
			_categoriaService = categoriaService;
		}

		[HttpPost]
		public async Task<IActionResult> AdicionarCategoria([FromBody] CategoriaModel categoria)
		{
			var result = await _categoriaService.AdicionarCategoria(categoria);
			return result;
		}

		[HttpGet("{categoriaId}")]
		public async Task<IActionResult> VisualizarCategoria(int categoriaId)
		{
			var result = await _categoriaService.VisualizarCategoria(categoriaId);
			return result;
		}

		[HttpGet]
		public async Task<IActionResult> ObterTodasCategorias()
		{
			var result = await _categoriaService.ObterTodasCategorias();
			return result;
		}

		[HttpPut("{categoriaId}")]
		public async Task<IActionResult> AtualizarCategoria(int categoriaId, [FromBody] CategoriaModel categoria)
		{
			var result = await _categoriaService.AtualizarCategoria(categoriaId, categoria);
			return result ?? NotFound("Categoria não encontrada.");
		}

		[HttpDelete("{categoriaId}")]
		public async Task<IActionResult> RemoverCategoria(int categoriaId)
		{
			var result = await _categoriaService.RemoverCategoria(categoriaId);
			return result;
		}
	}
}
