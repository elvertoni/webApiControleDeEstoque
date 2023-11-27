// produto-listar.component.ts

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar'; // Importe MatSnackBar

@Component({
  selector: 'app-produto-listar',
  templateUrl: './produto-listar.component.html',
  styleUrls: ['./produto-listar.component.css'],
})
export class ProdutoListarComponent implements OnInit {
  produtos: any[] = [];

  constructor(private http: HttpClient, private router: Router, private snackBar: MatSnackBar) {} // Injetado MatSnackBar no construtor

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.http.get<any>('https://localhost:7258/Estoque/Produto').subscribe(
      (data) => {
        this.produtos = data.$values; // Ajuste aqui conforme a estrutura do seu objeto
      },
      (error) => {
        console.error('Erro ao obter a lista de produtos', error);
      }
    );
  }

  formatarData(data: string): string {
    const date = new Date(data);
    const day = date.getDate();
    const month = date.getMonth() + 1; // Adicionando 1 aqui para compensar a base zero do getMonth()
    const year = date.getFullYear();
    const formattedDay = day < 10 ? '0' + day : day;
    const formattedMonth = month < 10 ? '0' + month : month;

    return `${formattedDay}/${formattedMonth}/${year}`;
  }

  editarProduto(id: number): void {
    this.router.navigate(["/produto-alterar", id]);
  }

  excluirProduto(produtoId: number): void {
    const apiUrl = `https://localhost:7258/Estoque/Produto/${produtoId}`;

    this.http.delete(apiUrl, { responseType: 'text' }).subscribe(
      (response) => {
        console.log(response);
        this.produtos = this.produtos.filter((produto) => produto.id !== produtoId);
        this.snackBar.open(response, 'Fechar');
      },
      (error: HttpErrorResponse) => {
        console.error('Erro ao excluir produto', error);

        if (error.status === 404) {
          this.snackBar.open('Produto não encontrado.', 'Fechar');
        } else {
          this.snackBar.open('Erro ao excluir produto.', 'Fechar');
        }
      }
    );
  }
}
