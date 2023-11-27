using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace estoque.Services
{
    public class FornecedorServices : IFornecedor
    {
        private readonly EstoqueContext _context;
        private readonly ILogger<FornecedorServices> _logger;

        public FornecedorServices(EstoqueContext context, ILogger<FornecedorServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> AdicionarFornecedor(FornecedorModel fornecedor)
        {
            if (fornecedor == null)
            {
                return new BadRequestObjectResult("Fornecedor inválido.");
            }

            try
            {
                // Certifique-se de que a coleção de categorias esteja preenchida
                fornecedor.FornecedorCategoria = new List<FornecedorCategoria>();

                // Verifique se o CNPJ já existe
                if (_context.Fornecedores.Any(f => f.CNPJ == fornecedor.CNPJ))
                {
                    _logger.LogWarning($"Tentativa de cadastrar fornecedor com CNPJ já existente: {fornecedor.CNPJ}");
                    return new BadRequestObjectResult("CNPJ já existe. Não é possível cadastrar fornecedor.");
                }

                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return new CreatedResult("Fornecedor adicionado com sucesso.", fornecedor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao adicionar fornecedor: {ex.Message}");
                return new BadRequestObjectResult($"Erro ao adicionar fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoverFornecedor(int fornecedorId)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.Include(f => f.FornecedorCategoria).FirstOrDefaultAsync(f => f.Id == fornecedorId);
                if (fornecedor == null)
                {
                    return new NotFoundObjectResult("Fornecedor não encontrado.");
                }

                // Remova as associações FornecedorCategoria
                _context.FornecedorCategorias.RemoveRange(fornecedor.FornecedorCategoria!);

                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Fornecedor removido com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao remover fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> AtualizarFornecedor(int fornecedorId, FornecedorModel fornecedor)
        {
            try
            {
                var existingFornecedor = await _context.Fornecedores.Include(f => f.FornecedorCategoria).FirstOrDefaultAsync(f => f.Id == fornecedorId);
                if (existingFornecedor == null)
                {
                    return new NotFoundObjectResult("Fornecedor não encontrado.");
                }

                existingFornecedor.Nome = fornecedor.Nome;
                existingFornecedor.Endereco = fornecedor.Endereco;
                existingFornecedor.Telefone = fornecedor.Telefone;
                existingFornecedor.CNPJ = fornecedor.CNPJ;

                // Atualize as associações FornecedorCategoria
                existingFornecedor.FornecedorCategoria = fornecedor.FornecedorCategoria;

                _context.Update(existingFornecedor);
                await _context.SaveChangesAsync();

                return new OkObjectResult("Fornecedor atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao atualizar fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> VisualizarFornecedor(int fornecedorId)
        {
            try
            {
                var fornecedor = await _context.Fornecedores
                    .Include(f => f.FornecedorCategoria)
                    .Where(f => f.Id == fornecedorId)
                    .Select(f => new
                    {
                        f.Id,
                        f.Nome,
                        f.Endereco,
                        f.Telefone,
                        f.CNPJ
                    })
                    .FirstOrDefaultAsync();

                if (fornecedor == null)
                {
                    return new NotFoundObjectResult("Fornecedor não encontrado.");
                }

                return new OkObjectResult(fornecedor);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Erro ao visualizar fornecedor.");
            }
        }

        public async Task<IActionResult> ObterTodosFornecedores()
        {
            try
            {
                var fornecedores = await _context.Fornecedores
                    .Include(f => f.FornecedorCategoria)
                    .Select(f => new
                    {
                        f.Id,
                        f.Nome,
                        f.Endereco,
                        f.Telefone,
                        f.CNPJ
                    })
                    .ToListAsync();

                return new OkObjectResult(fornecedores);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao obter fornecedores: {ex.Message}");
            }
        }
    }
}