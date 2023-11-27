using Microsoft.AspNetCore.Mvc;
using estoque.Data;
using Microsoft.EntityFrameworkCore;




namespace estoque.Controllers
{
    [Route("Estoque/[controller]")]
    [ApiController]
    public class FornecedorCategoriaController : ControllerBase
    {
        private readonly EstoqueContext _context;
        private readonly ILogger<FornecedorCategoriaController> _logger;

        public FornecedorCategoriaController(EstoqueContext context, ILogger<FornecedorCategoriaController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todasFornecedorCategorias = await _context.FornecedorCategorias
                    .Include(fc => fc.Fornecedor)
                    .Include(fc => fc.Categoria)
                    .ToListAsync();

                return new OkObjectResult(todasFornecedorCategorias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as interações de fornecedores e categorias");
                return new BadRequestObjectResult($"Erro ao obter todas as interações: {ex.Message}");
            }
        }


        // Obter todas as interações para um FornecedorID
        [HttpGet("PorFornecedor/{fornecedorId}")]
        public async Task<IActionResult> ObterPorFornecedor(int fornecedorId)
        {
            try
            {
                var interacoesFornecedor = await _context.FornecedorCategorias
                    .Where(fc => fc.FornecedorId == fornecedorId)
                    .ToListAsync();

                return new OkObjectResult(interacoesFornecedor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter interações para Fornecedor com ID {fornecedorId}");
                return new BadRequestObjectResult($"Erro ao obter interações para Fornecedor: {ex.Message}");
            }
        }

        // Obter todas as interações para uma CategoriaID
        [HttpGet("PorCategoria/{categoriaId}")]
        public async Task<IActionResult> ObterPorCategoria(int categoriaId)
        {
            try
            {
                var interacoesCategoria = await _context.FornecedorCategorias
                    .Where(fc => fc.CategoriaId == categoriaId)
                    .ToListAsync();

                return new OkObjectResult(interacoesCategoria);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter interações para Categoria com ID {categoriaId}");
                return new BadRequestObjectResult($"Erro ao obter interações para Categoria: {ex.Message}");
            }
        }
    }
}
