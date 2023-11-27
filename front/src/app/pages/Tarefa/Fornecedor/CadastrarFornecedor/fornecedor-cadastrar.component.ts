import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { Fornecedor } from '../../../../models/Fornecedor.models';

@Component({
  selector: 'app-fornecedor-cadastrar',
  templateUrl: './fornecedor-cadastrar.component.html',
  styleUrls: ['./fornecedor-cadastrar.component.css']
})
export class FornecedorCadastrarComponent {
  fornecedorForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router) {
    this.fornecedorForm = this.formBuilder.group({
      nome: ['', Validators.required],
      endereco: ['', Validators.required],
      telefone: ['', Validators.required],
      cnpj: ['', Validators.required],
    });
  }

  cadastrarFornecedor() {
    if (this.fornecedorForm.valid) {
      const novoFornecedor: Fornecedor = {
        id: 0,
        nome: this.fornecedorForm.value.nome,
        endereco: this.fornecedorForm.value.endereco,
        telefone: this.fornecedorForm.value.telefone,
        cnpj: this.fornecedorForm.value.cnpj,
        fornecedorCategoria: []
      };

      this.httpClient.post<Fornecedor>('https://localhost:7258/estoque/fornecedor', novoFornecedor)
        .subscribe(
          (response) => {
            console.log('Fornecedor cadastrado com sucesso:', response);
            this.router.navigate(['/listar-fornecedores']);
          },
          (error) => {
            console.error('Erro ao cadastrar fornecedor:', error);

            if (error instanceof HttpErrorResponse && error.status === 400) {
              // Se for um erro 400, verifica se é um erro de CNPJ duplicado
              const errorMessage = error.error as string;
              if (errorMessage.includes('CNPJ já existe')) {
                window.alert('CNPJ já foi cadastrado anteriormente.');
              } else {
                // Outros erros de validação podem ser tratados aqui conforme necessário
              }
            } else {
              // Outros erros podem ser tratados aqui conforme necessário
            }
          }
        );
    } else {
      console.error('Formulário inválido. Verifique os campos.');
    }
  }
}