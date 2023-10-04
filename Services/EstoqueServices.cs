using estoque.Data;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace estoque.Services
{
    public class EstoqueServices
    {
        private readonly EstoqueContext _context;

        public EstoqueServices(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdicionarEstoque(EstoqueModel estoque)
        {
            if (estoque == null)
            {
                return new BadRequestObjectResult("Entrada de estoque inválida.");
            }

            try
            {
                _context.Estoque.Add(estoque);
                await _context.SaveChangesAsync();
                return new CreatedResult("Entrada de estoque adicionada com sucesso.", estoque);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao adicionar entrada de estoque: {ex.Message}");
            }
        }

        public async Task<IActionResult> VisualizarEstoque(int produtoId)
        {
            try
            {
                var estoque = await _context.Estoque.FirstOrDefaultAsync(e => e.IdProduto == produtoId);
                if (estoque == null)
                {
                    return new NotFoundObjectResult("Entrada de estoque não encontrada.");
                }

                return new OkObjectResult(estoque);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Erro ao visualizar entrada de estoque.");
            }
        }

        public async Task<IActionResult> ObterTodosEstoque()
        {
            try
            {
                var Estoque = await _context.Estoque.ToListAsync();
                return new OkObjectResult(Estoque);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao obter entradas de estoque: {ex.Message}");
            }
        }

        public async Task<IActionResult> AtualizarEstoque(EstoqueModel estoque)
        {
            try
            {
                var existingEstoque = await _context.Estoque.FirstOrDefaultAsync(e => e.IdProduto == estoque.IdProduto);
                if (existingEstoque == null)
                {
                    return new NotFoundObjectResult("Entrada de estoque não encontrada.");
                }

                // Atualize os campos de estoque conforme necessário
                existingEstoque.NívelEstoqueMínimo = estoque.NívelEstoqueMínimo;
                existingEstoque.NívelEstoqueMáximo = estoque.NívelEstoqueMáximo;

                _context.Update(existingEstoque);
                await _context.SaveChangesAsync();

                return new OkObjectResult("Entrada de estoque atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao atualizar entrada de estoque: {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoverEstoque(int produtoId)
        {
            try
            {
                var estoque = await _context.Estoque.FirstOrDefaultAsync(e => e.IdProduto == produtoId);
                if (estoque == null)
                {
                    return new NotFoundObjectResult("Entrada de estoque não encontrada.");
                }

                _context.Estoque.Remove(estoque);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Entrada de estoque removida com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao remover entrada de estoque: {ex.Message}");
            }
        }

        internal Task<IActionResult> ObterTodosEstoques()
        {
            throw new NotImplementedException();
        }

    }
}
