import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormArray,
  FormControl,
} from "@angular/forms";
import { HttpClient, HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Categoria, Fornecedor } from "src/app/models/Categoria.models";

@Component({
  selector: "app-categoria-alterar",
  templateUrl: "./categoria-alterar.component.html",
  styleUrls: ["./categoria-alterar.component.css"],
})
export class CategoriaAlterarComponent implements OnInit {
  categoriaID: number;
  categoria: Categoria | null = null;
  categoriaForm: FormGroup;
  mensagemErro: string = "";
  mensagemSucesso: string = "";
  fornecedoresSelecionados: number[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private snackBar: MatSnackBar
  ) {
    this.categoriaID = 0;
    this.categoriaForm = this.fb.group({
      nome: ["", Validators.required],
      descricao: ["", Validators.required],
      fornecedorIds: this.fb.array([]),
    });
  }

  ngOnInit(): void {
    this.categoriaID = +this.route.snapshot.paramMap.get("id")!;

    console.log("Categoria ID:", this.categoriaID);

    this.httpClient
      .get<Categoria>(
        `https://localhost:7258/estoque/categoria/${this.categoriaID}`
      )
      .subscribe(
        (response) => {
          console.log("Resposta da API:", response);
          this.categoria = response || null;
          this.populateForm();
        },
        (error) => {
          console.error("Erro ao obter detalhes da categoria", error);
        }
      );
  }

  private populateForm(): void {
    if (this.categoria) {
      this.categoriaForm.patchValue({
        nome: this.categoria.nome,
        descricao: this.categoria.descricao,
      });

      this.categoria.fornecedores = [];
      this.carregarFornecedores();
    }
  }

  carregarFornecedores() {
    this.httpClient
      .get<any>("https://localhost:7258/estoque/Fornecedor")
      .subscribe(
        (response) => {
          console.log("Resposta da API:", response);
          const fornecedoresArray = response.$values || [];
          if (this.categoria) {
            this.categoria.fornecedores = fornecedoresArray;
          }

          this.categoria?.fornecedores.forEach((fornecedor: Fornecedor) => {
            const formArray = this.categoriaForm.get(
              "fornecedorIds"
            ) as FormArray;
            formArray.push(new FormControl(fornecedor.id));
          });
        },
        (error: HttpErrorResponse) => {
          console.error("Erro ao obter fornecedores", error);
        }
      );
  }

  onCheckboxChange(event: any, fornecedor: Fornecedor) {
    if (event.target.checked) {
      if (!this.fornecedoresSelecionados.includes(fornecedor.id)) {
        this.fornecedoresSelecionados.push(fornecedor.id);
      }
    } else {
      const index = this.fornecedoresSelecionados.indexOf(fornecedor.id);
      if (index !== -1) {
        this.fornecedoresSelecionados.splice(index, 1);
      }
    }
  }

  atualizarCategoria() {
  if (this.categoriaForm.valid && this.categoria) {
    const categoriaData: any = {
      id: this.categoriaID,
      nome: this.categoriaForm.value.nome,
      descricao: this.categoriaForm.value.descricao,
      fornecedorIds: this.fornecedoresSelecionados,
    };

    console.log("Dados da Categoria a serem enviados:", categoriaData);

    this.httpClient
      .put(
        `https://localhost:7258/estoque/categoria/${this.categoriaID}`,
        categoriaData,
        { observe: 'response', responseType: 'text' }  // Adiciona esta opção para tratar como texto
      )
      .subscribe(
        (response: HttpResponse<any>) => {
          console.log("Resposta do servidor:", response);
          if (response.status === 200) {
            this.mensagemSucesso = response.body;
            this.mensagemErro = "";
            this.router.navigate(["/listar-categoria"]);
          }
        },
        (error: HttpErrorResponse) => {
          console.error("Erro ao atualizar categoria", error);
          if (error instanceof HttpErrorResponse) {
            console.error("Status:", error.status);
            console.error("Mensagem de erro:", error.error);

            this.mensagemErro =
              error.error ||
              "Não é possível atualizar a categoria. Certifique-se de fornecer o ID da categoria e do fornecedor associados ao produto.";
            this.mensagemSucesso = "";

            // Adicione a chamada para exibir o alerta aqui
            this.mostrarAlertaErro();
          }
        }
      );
  } else {
    console.log("Formulário inválido. Por favor, corrija os campos destacados.");
    this.mensagemErro =
      "Formulário inválido. Por favor, corrija os campos destacados.";
    this.mensagemSucesso = "";
  }
}

mostrarAlertaErro(): void {
  this.snackBar.open(
    this.mensagemErro,
    "Fechar",
    {
      duration: 5000,
      panelClass: ["aviso-snackbar"],
    }
  );
}

  mostrarMensagemProdutosRelacionadosFornecedoresNaoSelecionados(): void {
    this.snackBar.open(
      "Não é possível atualizar a categoria devido à existência de produtos relacionados a fornecedores não selecionados.",
      "Fechar",
      {
        duration: 5000,
        panelClass: ["aviso-snackbar"],
      }
    );
  }
}
