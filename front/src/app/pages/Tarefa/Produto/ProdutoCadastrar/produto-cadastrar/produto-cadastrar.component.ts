// produto-cadastrar.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ProdutoModel } from 'src/app/models/Produto.models';

@Component({
  selector: 'app-produto-cadastrar',
  templateUrl: './produto-cadastrar.component.html',
  styleUrls: ['./produto-cadastrar.component.css']
})
export class ProdutoCadastrarComponent implements OnInit {
  produtoForm: FormGroup;
  fornecedores: any[] = [];
  categorias: any[] = [];

  constructor(
    private fb: FormBuilder,
    private httpClient: HttpClient,
    private router: Router
  ) {
    this.produtoForm = this.fb.group({
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
      preco: [0, [Validators.required, Validators.min(1)]],
      quantidadeEstoque: [0, [Validators.required, Validators.min(1)]],
      dataValidade: [null, [Validators.required, this.minDateValidator()]],
      idFornecedor: [null, Validators.required],
      idCategoria: [null, Validators.required],
    });

    this.carregarFornecedores();
    this.carregarCategorias();
  }

  ngOnInit() {
    this.produtoForm.get('dataValidade')?.setValidators([
      Validators.required,
      this.minDateValidator()
    ]);
    this.produtoForm.get('dataValidade')?.updateValueAndValidity();
  }

  carregarFornecedores() {
    this.httpClient.get('https://localhost:7258/Estoque/fornecedor')
      .subscribe(
        (response: any) => {
          this.fornecedores = response.$values;
        },
        (error: HttpErrorResponse) => {
          console.error('Erro ao carregar fornecedores', error);
        }
      );
  }

  carregarCategorias() {
    this.httpClient.get('https://localhost:7258/Estoque/categoria')
      .subscribe(
        (response: any) => {
          this.categorias = response.$values;
        },
        (error: HttpErrorResponse) => {
          console.error('Erro ao carregar categorias', error);
        }
      );
  }


 

  cadastrarProduto() {
    if (this.isFormValid()) {
      const produtoData: ProdutoModel = this.produtoForm.value;

      this.httpClient.post('https://localhost:7258/Estoque/Produto', produtoData)
        .subscribe(
          () => {
            console.log('Produto cadastrado com sucesso!');
            this.router.navigate(['/produto-listar']);
          },
          (error: HttpErrorResponse) => {
            console.error('Erro ao cadastrar produto', error);
          }
        );
    } else {
      console.log('Formulário inválido. Por favor, corrija os campos destacados.');
      console.log('Erros globais:', this.produtoForm.errors);
      console.log('Controles inválidos:', this.getInvalidControls(this.produtoForm));
    }
  }

  isFormValid(): boolean {
    return this.produtoForm.valid &&
      this.produtoForm.get('preco')?.value > 0 &&
      this.produtoForm.get('quantidadeEstoque')?.value > 0 &&
      this.produtoForm.get('nome')?.value.trim() !== '' &&
      this.produtoForm.get('descricao')?.value.trim() !== '';
  }

  getInvalidControls(form: FormGroup) {
    const invalidControls: any[] = [];
    const recursiveCheck = (control: any) => {
      if (control.invalid) {
        invalidControls.push(control);
      }
      if (control instanceof FormGroup) {
        for (const key in control.controls) {
          recursiveCheck(control.controls[key]);
        }
      }
    };
    recursiveCheck(form);
    return invalidControls;
  }

  minDateValidator() {
    return (control: { value: string | number | Date; }) => {
      const currentDate = new Date();
      const selectedDate = new Date(control.value);

      if (control.value && selectedDate < currentDate) {
        return { minDate: true };
      }

      return null;
    };
  }

  get minDate(): string {
    const currentDate = new Date();
    return currentDate.toISOString().split('T')[0];
  }
}
