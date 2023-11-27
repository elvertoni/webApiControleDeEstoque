using estoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace estoque.Interfaces
{
    public interface IFornecedor
    {
        Task<IActionResult> AdicionarFornecedor(FornecedorModel fornecedor);
        Task<IActionResult> RemoverFornecedor(int fornecedorId);
        Task<IActionResult> VisualizarFornecedor(int fornecedorId);
        Task<IActionResult> AtualizarFornecedor(int fornecedorId, FornecedorModel fornecedor);
        Task<IActionResult> ObterTodosFornecedores();
    }
}
