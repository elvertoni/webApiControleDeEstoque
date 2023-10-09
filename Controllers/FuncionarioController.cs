using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace estoque.Controllers
{
    [Route("Estoque/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _funcionarioService;

        public FuncionarioController(IFuncionario funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFuncionario([FromBody] FuncionarioModel funcionario)
        {
            return await _funcionarioService.AdicionarFuncionario(funcionario);
        }

        [HttpGet("{funcionarioId}")]
        public async Task<IActionResult> VisualizarFuncionario(int funcionarioId)
        {
            return await _funcionarioService.VisualizarFuncionario(funcionarioId);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosFuncionarioes()
        {
            return await _funcionarioService.ObterTodosFuncionarios();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarFuncionario([FromBody] FuncionarioModel funcionario)
        {
            return await _funcionarioService.AtualizarFuncionario(funcionario);
        }

        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> RemoverFuncionario(int funcionarioId)
        {
            return await _funcionarioService.RemoverFuncionario(funcionarioId);
        }
    }
}
