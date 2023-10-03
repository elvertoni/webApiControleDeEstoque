namespace estoque.Interfaces;
using estoque.Models;

public interface IProduto
{
    void AdicionarProduto(ProdutoModel produto);
    void RemoverProduto(int produtoId);
    void AtualizarPreço(int produtoId, double novoPreço);
    void AtualizarQuantidade(int produtoId, double novaQuantidade);
    string GetNome();
    void SetNome(string nome);
    string GetDescrição();
    void SetDescrição(string descrição);
    double GetPreço();
    void SetPreço(double preço);
    double GetQuantidadeEstoque();
    void SetQuantidadeEstoque(double quantidadeEstoque);
}