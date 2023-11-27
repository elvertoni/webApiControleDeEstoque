using Microsoft.AspNetCore.Mvc;
using estoque.Models;

namespace estoque.Interfaces
{
    public interface ICategoria
    {

        Task<IActionResult> RemoverCategoria(int categoriaId);
        Task<IActionResult> VisualizarCategoria(int categoriaId);
        Task<IActionResult> AtualizarCategoria(int categoriaId, CategoriaModel categoria);
        Task<IActionResult> ObterTodasCategorias();
    }
}