using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace estoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedor _fornecedorService;

        public FornecedorController(IFornecedor fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFornecedor([FromBody] FornecedorModel fornecedor)
        {
            return await _fornecedorService.AdicionarFornecedor(fornecedor);
        }

        [HttpGet("{fornecedorId}")]
        public async Task<IActionResult> VisualizarFornecedor(int fornecedorId)
        {
            return await _fornecedorService.VisualizarFornecedor(fornecedorId);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosFornecedores()
        {
            return await _fornecedorService.ObterTodosFornecedores();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarFornecedor([FromBody] FornecedorModel fornecedor)
        {
            return await _fornecedorService.AtualizarFornecedor(fornecedor);
        }

        [HttpDelete("{fornecedorId}")]
        public async Task<IActionResult> RemoverFornecedor(int fornecedorId)
        {
            return await _fornecedorService.RemoverFornecedor(fornecedorId);
        }
    }
}
