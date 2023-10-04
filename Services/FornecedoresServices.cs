using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace estoque.Services
{
    public class FornecedorServices : IFornecedor
    {
        private readonly EstoqueContext _context;

        public FornecedorServices(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdicionarFornecedor(FornecedorModel fornecedor)
        {
            if (fornecedor == null)
            {
                return new BadRequestObjectResult("Fornecedor inválido.");
            }

            try
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return new CreatedResult("Fornecedor adicionado com sucesso.", fornecedor);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao adicionar fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoverFornecedor(int fornecedorId)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(fornecedorId);
                if (fornecedor == null)
                {
                    return new NotFoundObjectResult("Fornecedor não encontrado.");
                }

                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Fornecedor removido com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao remover fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> VisualizarFornecedor(int fornecedorId)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(fornecedorId);
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

        public async Task<IActionResult> AtualizarFornecedor(FornecedorModel fornecedor)
        {
            try
            {
                var existingFornecedor = await _context.Fornecedores.FindAsync(fornecedor.Id);
                if (existingFornecedor == null)
                {
                    return new NotFoundObjectResult("Fornecedor não encontrado.");
                }

                existingFornecedor.Nome = fornecedor.Nome;
                existingFornecedor.Endereco = fornecedor.Endereco;
                existingFornecedor.Telefone = fornecedor.Telefone;
                existingFornecedor.CNPJ = fornecedor.CNPJ;

                _context.Update(existingFornecedor);
                await _context.SaveChangesAsync();

                return new OkObjectResult("Fornecedor atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao atualizar fornecedor: {ex.Message}");
            }
        }

        public async Task<IActionResult> ObterTodosFornecedores()
        {
            try
            {
                var fornecedores = await _context.Fornecedores.ToListAsync();
                return new OkObjectResult(fornecedores);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao obter fornecedores: {ex.Message}");
            }
        }
    }
}
