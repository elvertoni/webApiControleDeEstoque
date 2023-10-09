using estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace estoque.Interfaces
{
    public interface IFuncionario
    {
        Task<IActionResult> AdicionarFuncionario(FuncionarioModel funcionario);
        Task<IActionResult> RemoverFuncionario(int funcionarioId);
        Task<IActionResult> VisualizarFuncionario(int funcionarioId);
        Task<IActionResult> AtualizarFuncionario(FuncionarioModel funcionario);
        Task<IActionResult> ObterTodosFuncionarios();
    }
}
