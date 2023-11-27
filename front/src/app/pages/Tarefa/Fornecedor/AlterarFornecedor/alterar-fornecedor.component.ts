import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: "app-alterar-fornecedor",
  templateUrl: "./alterar-fornecedor.component.html",
  styleUrls: ["./alterar-fornecedor.component.css"],
})
export class AlterarFornecedorComponent implements OnInit {
  fornecedorID: number;
  fornecedor: any = {};
  fornecedorForm: FormGroup;
  mensagemErro: string = "";
  mensagemSucesso: string = "";

  private apiUrl = "https://localhost:7258/estoque/fornecedor";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private httpClient: HttpClient,
    private fb: FormBuilder
  ) {
    this.fornecedorID = 0;
    this.fornecedorForm = this.fb.group({
      nome: ["", Validators.required],
      endereco: ["", Validators.required],
      telefone: ["", Validators.required],
      cnpj: ["", Validators.required],
    });
  }

  ngOnInit(): void {
    this.fornecedorID = +this.route.snapshot.paramMap.get("id")!;

    this.httpClient.get(`${this.apiUrl}/${this.fornecedorID}`).subscribe(
      (response) => {
        this.fornecedor = response;
        this.populateForm();
      },
      (error) => {
        console.error("Erro ao obter detalhes do fornecedor", error);
      }
    );
  }

  private populateForm(): void {
    this.fornecedorForm.patchValue({
      nome: this.fornecedor.nome,
      endereco: this.fornecedor.endereco,
      telefone: this.fornecedor.telefone,
      cnpj: this.fornecedor.cnpj,
    });
  }

  atualizarFornecedor() {
    if (this.fornecedorForm.valid) {
      if (!this.fornecedor.FornecedorCategoria) {
        this.fornecedor.FornecedorCategoria = [];
      }

      // Crie um novo objeto para representar os dados a serem enviados
      const fornecedorData = {
        id: this.fornecedorID,
        nome: this.fornecedorForm.value.nome,
        endereco: this.fornecedorForm.value.endereco,
        telefone: this.fornecedorForm.value.telefone,
        cnpj: this.fornecedorForm.value.cnpj,
      };

      console.log("Dados do Fornecedor a serem enviados:", fornecedorData);

      this.httpClient
        .put(`${this.apiUrl}/${this.fornecedorID}`, fornecedorData, { responseType: 'text' })
        .subscribe(
          () => {
            console.log("Fornecedor atualizado com sucesso!");
            this.mensagemSucesso = "Fornecedor atualizado com sucesso!";
            this.mensagemErro = ""; 
            this.router.navigate(['/listar-fornecedores']);
          },
          (error: HttpErrorResponse) => {
            console.error("Erro ao atualizar fornecedor", error);
            if (error instanceof HttpErrorResponse) {
              console.error("Status:", error.status);
              console.error("Mensagem de erro:", error.error);

              // Adicione um alerta específico para CNPJ duplicado
              if (error.status === 400 && error.error.includes('CNPJ já existe para outro fornecedor')) {
                window.alert("CNPJ já está em uso por outro Fornecedor");
              }

              this.mensagemErro = `Erro: ${error.status} - ${error.error}`;
              this.mensagemSucesso = ""; // Limpa qualquer mensagem de sucesso anterior
              // Adicione aqui a lógica para exibir uma mensagem de erro na interface do usuário, se desejar.
            }
          }
        );
    } else {
      console.log(
        "Formulário inválido. Por favor, corrija os campos destacados."
      );
      this.mensagemErro =
        "Formulário inválido. Por favor, corrija os campos destacados.";
      this.mensagemSucesso = ""; // Limpa qualquer mensagem de sucesso anterior
      // Adicione aqui a lógica para exibir uma mensagem de erro na interface do usuário, se desejar.
    }
  }
}