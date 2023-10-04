using System.Threading.Tasks;
using estoque.Models;
using estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace estoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueServices _estoqueService;

        public EstoqueController(EstoqueServices estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEstoque([FromBody] EstoqueModel estoque)
        {
            return await _estoqueService.AdicionarEstoque(estoque);
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> VisualizarEstoque(int produtoId)
        {
            return await _estoqueService.VisualizarEstoque(produtoId);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosEstoques()
        {
            return await _estoqueService.ObterTodosEstoques();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarEstoque([FromBody] EstoqueModel estoque)
        {
            return await _estoqueService.AtualizarEstoque(estoque);
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> RemoverEstoque(int produtoId)
        {
            return await _estoqueService.RemoverEstoque(produtoId);
        }
    }
}
