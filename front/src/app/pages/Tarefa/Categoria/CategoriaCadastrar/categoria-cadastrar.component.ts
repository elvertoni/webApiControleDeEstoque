import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { Fornecedor } from '../../../../models/Fornecedor.models';

@Component({
  selector: 'app-categoria-cadastrar',
  templateUrl: './categoria-cadastrar.component.html',
  styleUrls: ['./categoria-cadastrar.component.css']
})
export class CategoriaCadastrarComponent implements OnInit {
  categoriaForm: FormGroup;
  mensagemErro: string = "";
  mensagemSucesso: string = "";
  fornecedores: Fornecedor[] = [];

  private apiUrl = "https://localhost:7258/estoque/categoria";

  constructor(
    private fb: FormBuilder,
    private httpClient: HttpClient,
    private router: Router
  ) {
    this.categoriaForm = this.fb.group({
      nome: ["", Validators.required],
      descricao: ["", Validators.required],
      fornecedorIds: this.fb.array([]), // Usaremos um FormArray para os fornecedores
    });
  }

  ngOnInit(): void {
    // Carregar fornecedores ao iniciar o componente
    this.carregarFornecedores();
  }

  carregarFornecedores() {
    // Fazer uma requisição GET para obter a lista de fornecedores
    this.httpClient.get<any>("https://localhost:7258/estoque/Fornecedor")
      .subscribe(
        (response) => {
          console.log("Resposta da API:", response); // Adicione esta linha
          // Certifique-se de que fornecedores seja uma matriz
          const fornecedoresArray = response.$values || [];
          this.fornecedores = fornecedoresArray;
          console.log(this.fornecedores);
        },
        (error: HttpErrorResponse) => {
          console.error("Erro ao obter fornecedores", error);
          // Adicione tratamento de erro conforme necessário
        }
      );
  }
  cadastrarCategoria() {
    if (this.categoriaForm.valid) {
      const categoriaData = {
        nome: this.categoriaForm.value.nome,
        descricao: this.categoriaForm.value.descricao,
        fornecedorIds: this.categoriaForm.value.fornecedorIds,
      };

      console.log("Dados da Categoria a serem enviados:", categoriaData);

      this.httpClient
        .post(this.apiUrl, categoriaData, { responseType: 'text' })
        .subscribe(
          () => {
            console.log("Categoria cadastrada com sucesso!");
            this.mensagemSucesso = "Categoria cadastrada com sucesso!";
            this.mensagemErro = "";
            this.router.navigate(['/listar-categoria']);
          },
          (error: HttpErrorResponse) => {
            console.error("Erro ao cadastrar categoria", error);
            if (error instanceof HttpErrorResponse) {
              console.error("Status:", error.status);
              console.error("Mensagem de erro:", error.error);
              this.mensagemErro = `Erro: ${error.status} - ${error.error}`;
              this.mensagemSucesso = "";
            }
          }
        );
    } else {
      console.log(
        "Formulário inválido. Por favor, corrija os campos destacados."
      );
      this.mensagemErro =
        "Formulário inválido. Por favor, corrija os campos destacados.";
      this.mensagemSucesso = "";
    }
  }

  // Adiciona ou remove fornecedorIds no FormArray conforme as checkboxes são marcadas/desmarcadas
  onCheckboxChange(event: any, fornecedor: Fornecedor) {
    const formArray = this.categoriaForm.get('fornecedorIds') as FormArray;

    if (event.target.checked) {
      formArray.push(new FormControl(fornecedor.id));
    } else {
      const index = formArray.controls.findIndex(x => x.value === fornecedor.id);
      formArray.removeAt(index);
    }
  }
}