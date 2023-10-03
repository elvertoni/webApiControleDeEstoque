namespace estoque.Interfaces;
using estoque.Models;



public interface ICategoria
{
    void AdicionarCategoria(CategoriaModel categoria);
    void RemoverCategoria(int categoriaId);
    CategoriaModel VisualizarCategoria(int categoriaId);
    void AtualizarCategoria(CategoriaModel categoria);
    string GetNome();
    void SetNome(string nome);
    string GetDescrição();
    void SetDescrição(string descrição);
}
