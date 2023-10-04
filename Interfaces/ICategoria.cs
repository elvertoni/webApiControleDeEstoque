using estoque.Models;
using Microsoft.AspNetCore.Mvc;


namespace estoque.Interfaces
{
    public interface ICategoria
    {
        Task<IActionResult> AdicionarCategoria(CategoriaModel categoria);
        Task<IActionResult> RemoverCategoria(int categoriaId);
        Task<IActionResult> VisualizarCategoria(int categoriaId);
        Task<IActionResult> AtualizarCategoria(CategoriaModel categoria);
        Task<IActionResult> ObterTodasCategorias();
    }
}