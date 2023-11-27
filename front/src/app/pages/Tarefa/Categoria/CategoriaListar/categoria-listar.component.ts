import { Component, OnInit } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Categoria } from "src/app/models/Categoria.models";
import { Router } from "@angular/router";

@Component({
  selector: "app-categoria-listar",
  templateUrl: "./categoria-listar.component.html",
  styleUrls: ["./categoria-listar.component.css"],
})
export class CategoriaListarComponent implements OnInit {
  categorias: Categoria[] = [];

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.getCategorias();
  }

  getCategorias(): void {
    this.http.get<any>("https://localhost:7258/estoque/categoria").subscribe(
      (data) => {
        console.log("Dados da API:", data);
        this.categorias = data.$values; // ou ajuste conforme a estrutura real

        // Atualiza as informações do fornecedor para cada categoria
        this.categorias.forEach((categoria) => {
          this.obterInformacoesFornecedor(categoria.id);
        });
      },
      (error) => {
        console.error("Erro ao obter categorias:", error);
      }
    );
  }

  obterInformacoesFornecedor(idCategoria: number): void {
    this.http
      .get<any>(
        `https://localhost:7258/Estoque/Categoria/InfosFornecedores/${idCategoria}`
      )
      .subscribe(
        (data) => {
          console.log("Informações do Fornecedor:", data);

          // Verifica se há dados do fornecedor
          if (data && data.$values && data.$values.length > 0) {
            const fornecedores = data.$values;

            // Atualiza as informações do fornecedor na categoria correspondente
            const categoria = this.categorias.find((c) => c.id === idCategoria);

            if (categoria) {
              categoria.fornecedores = fornecedores;
            } else {
              console.warn("Categoria não encontrada.");
            }
          } else {
            console.warn("Nenhum dado de fornecedor retornado.");
          }
        },
        (error) => {
          console.error("Erro ao obter informações do fornecedor:", error);
        }
      );
  }

  editarCategoria(id: number): void {
    // Navegue para a rota de edição com o ID da categoria
    this.router.navigate(["/alterar-categoria", id]);
  }

  excluirCategoria(id: number): void {
    // Antes de excluir, verifique se há produtos referenciando a categoria
    this.verificarProdutosDaCategoria(id);
  }

  verificarProdutosDaCategoria(categoriaId: number): void {
    const apiUrl = `https://localhost:7258/estoque/categoria/verificarprodutos/${categoriaId}`;

    this.http.get<boolean>(apiUrl).subscribe(
      (temProdutos: boolean) => {
        if (temProdutos) {
          // Existem produtos referenciando a categoria, informe o usuário
          const mensagem =
            "Esta categoria não pode ser excluída porque há produtos associados a ela.";
          window.alert(mensagem);
        } else {
          // Não há produtos referenciando a categoria, peça confirmação
          const confirmacao = window.confirm(
            "Tem certeza que deseja excluir esta categoria?"
          );

          // Se o usuário confirmar, proceda com a exclusão
          if (confirmacao) {
            this.efetuarExclusaoCategoria(categoriaId);
          }
        }
      },
      (error: any) => {
        console.error("Erro ao verificar produtos da categoria", error);

        if (error instanceof HttpErrorResponse) {
          console.error("Status:", error.status);
          console.error("Mensagem de erro:", error.error);
        }
      }
    );
  }
  efetuarExclusaoCategoria(categoriaId: number): void {
    const apiUrl = `https://localhost:7258/estoque/categoria/${categoriaId}`;

    this.http.delete(apiUrl, { responseType: "text" }).subscribe(
      (response) => {
        console.log("Categoria excluída com sucesso!");
        // Recarregue a lista de categorias após a exclusão
        this.getCategorias();
        window.alert(response); // Exibe a mensagem de sucesso diretamente
      },
      (error: any) => {
        console.error("Erro ao excluir categoria", error);

        if (error instanceof HttpErrorResponse) {
          console.error("Status:", error.status);
          console.error("Mensagem de erro:", error.error);
        }
      }
    );
  }
}
