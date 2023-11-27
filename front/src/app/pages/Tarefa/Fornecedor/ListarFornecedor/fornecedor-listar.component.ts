import { Component, OnInit } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";

import { Fornecedor } from "src/app/models/Fornecedor.models";

@Component({
  selector: "app-fornecedor-listar",
  templateUrl: "./fornecedor-listar.component.html",
  styleUrls: ["./fornecedor-listar.component.css"],
})
export class FornecedorListarComponent implements OnInit {
  fornecedores: Fornecedor[] = [];
  carregandoFornecedores = false;
  erroAoCarregar = false;

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    console.log("O componente foi carregado!");
    this.carregarFornecedores();
  }

  carregarFornecedores(): void {
    const apiUrl = "https://localhost:7258/estoque/fornecedor";
    this.carregandoFornecedores = true;

    this.httpClient.get<{ $values: Fornecedor[] }>(apiUrl).subscribe(
      (response) => {
        this.fornecedores = response.$values || [];
        this.carregandoFornecedores = false;
      },
      (erro) => {
        console.error("Erro ao carregar fornecedores", erro);
        this.erroAoCarregar = true;
        this.carregandoFornecedores = false;
      }
    );
  }

  editarFornecedor(id: number): void {
    this.router.navigate(["/alterar-fornecedor", id]);
  }

  excluirFornecedor(id: number): void {
    this.verificarProdutosDoFornecedor(id);
  }

  verificarProdutosDoFornecedor(fornecedorId: number): void {
    const apiUrl = `https://localhost:7258/estoque/fornecedor/produtos/${fornecedorId}`;

    this.httpClient.get<boolean>(apiUrl).subscribe(
      (temProdutos: boolean) => {
        if (temProdutos) {
          this.snackBar.open(
            "Este fornecedor não pode ser excluído porque há produtos associados a ele.",
            "Fechar"
          );
        } else {
          const confirmacao = window.confirm(
            "Tem certeza que deseja excluir este fornecedor?"
          );

          if (confirmacao) {
            this.efetuarExclusaoDoFornecedor(fornecedorId);
          }
        }
      },
      (error: HttpErrorResponse) => {
        console.error("Erro ao verificar produtos do fornecedor", error);

        if (error.status === 200) {
          // O backend agora retorna um booleano, então se o status for 200, consideramos que há produtos associados
          this.snackBar.open(
            "Este fornecedor não pode ser excluído porque há produtos associados a ele.",
            "Fechar"
          );
        } else {
          this.snackBar.open("Erro ao verificar produtos do fornecedor.", "Fechar");
        }
      }
    );
  }

  efetuarExclusaoDoFornecedor(fornecedorId: number): void {
    const apiUrl = `https://localhost:7258/estoque/fornecedor/${fornecedorId}`;

    this.httpClient.delete(apiUrl, { responseType: "text" }).subscribe(
      (response) => {
        console.log("Fornecedor excluído com sucesso!");
        this.fornecedores = this.fornecedores.filter(f => f.id !== fornecedorId);
        this.snackBar.open(response, "Fechar");
      },
      (error: any) => {
        console.error("Erro ao excluir fornecedor", error);

        if (error instanceof HttpErrorResponse) {
          console.error("Status:", error.status);
          console.error("Mensagem de erro:", error.error);
        }
      }
    );
  }
}
