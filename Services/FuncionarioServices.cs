using estoque.Data;
using estoque.Interfaces;
using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace estoque.Services
{
    public class FuncionarioServices : IFuncionario
    {
        private readonly EstoqueContext _context;
        private readonly IProduto _produtoService;
        private readonly ICategoria _categoriaService;
        private readonly IFornecedor _fornecedorService;

        public FuncionarioServices(EstoqueContext context, IProduto produtoService, ICategoria categoriaService, IFornecedor fornecedorService)
        {
            _context = context;
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _fornecedorService = fornecedorService;
        }

        // Métodos da interface IFuncionario

        public async Task<IActionResult> AdicionarFuncionario(FuncionarioModel funcionario)
        {
            if (funcionario == null)
            {
                return new BadRequestObjectResult("Funcionario inválido.");
            }

            try
            {
                _context.Funcionario.Add(funcionario);
                await _context.SaveChangesAsync();
                return new CreatedResult("Funcionario adicionado com sucesso.", funcionario);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao adicionar funcionario: {ex.Message}");
            }
        }

        public async Task<IActionResult> RemoverFuncionario(int funcionarioId)
        {
            try
            {
                var funcionario = await _context.Funcionario.FindAsync(funcionarioId);
                if (funcionario == null)
                {
                    return new NotFoundObjectResult("Funcionario não encontrado.");
                }

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Funcionario removido com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao remover funcionario: {ex.Message}");
            }
        }

        public async Task<IActionResult> VisualizarFuncionario(int funcionarioId)
        {
            try
            {
                var funcionario = await _context.Funcionario.FindAsync(funcionarioId);
                if (funcionario == null)
                {
                    return new NotFoundObjectResult("Funcionario não encontrado.");
                }

                return new OkObjectResult(funcionario);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Erro ao visualizar funcionario.");
            }
        }

        public async Task<IActionResult> AtualizarFuncionario(FuncionarioModel funcionario)
        {
            try
            {
                var existingFuncionario = await _context.Funcionario.FindAsync(funcionario.Id);
                if (existingFuncionario == null)
                {
                    return new NotFoundObjectResult("Funcionario não encontrado.");
                }

                existingFuncionario.Nome = funcionario.Nome;
                existingFuncionario.Cargo = funcionario.Cargo;
                // existingFuncionario.Login = funcionario.Login;
                // existingFuncionario.Senha = funcionario.Senha;   Verificar se atualiza nesse metodo mesmo

                _context.Update(existingFuncionario);
                await _context.SaveChangesAsync();

                return new OkObjectResult("Funcionario atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao atualizar funcionario: {ex.Message}");
            }
        }

        public async Task<IActionResult> ObterTodosFuncionarios()
        {
            try
            {
                var funcionarios = await _context.Funcionario.ToListAsync();
                return new OkObjectResult(funcionarios);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao obter funcionarios: {ex.Message}");
            }
        }
    }
}
