using estoque.Models;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
=======

>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
namespace estoque.Interfaces
{
    public interface ICategoria
    {
        Task<IActionResult> AdicionarCategoria(CategoriaModel categoria);
        Task<IActionResult> RemoverCategoria(int categoriaId);
        Task<IActionResult> VisualizarCategoria(int categoriaId);
<<<<<<< HEAD
        Task<IActionResult> AtualizarCategoria(int categoriaId, CategoriaModel categoria);
        Task<IActionResult> ObterTodasCategorias();
    }
}
=======
        Task<IActionResult> AtualizarCategoria(CategoriaModel categoria);
        Task<IActionResult> ObterTodasCategorias();
    }
}
>>>>>>> ef24d1360dcab72365daf732be8ec9bcb0a2e06b
