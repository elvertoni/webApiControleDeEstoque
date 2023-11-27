import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Categoria, Fornecedor } from '../../../../models/Categoria.models';
import { ProdutoModel } from '../../../../models/Produto.models';

@Component({
  selector: 'app-produto-alterar',
  templateUrl: './produto-alterar.component.html',
  styleUrls: ['./produto-alterar.component.css']
})
export class ProdutoAlterarComponent implements OnInit {
  produto: ProdutoModel = {} as ProdutoModel;
  fornecedores: Fornecedor[] = [];
  categorias: Categoria[] = [];
  mensagemSucesso: string | null = null;
  mensagemErro: string | null = null;
  produtoForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) {
    this.produtoForm = this.formBuilder.group({
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
      preco: [0, [Validators.required, Validators.min(1)]],
      quantidadeEstoque: [0, [Validators.required, Validators.min(1)]],
      dataValidade: ['', Validators.required],
      idCategoria: ['', Validators.required],
      idFornecedor: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    const idProduto = this.route.snapshot.paramMap.get('id');
    if (idProduto !== null) {
      this.carregarProduto(Number(idProduto));
    }

    this.carregarCategorias();
  }

  carregarCategorias(): void {
    this.httpClient.get<Categoria[]>('https://localhost:7258/Estoque/Categoria').subscribe(
      (categorias) => {
        this.categorias = categorias;
        this.carregarInformacoesCategoria();
      },
      (error) => {
        console.error('Erro ao carregar categorias', error);
        this.mensagemErro = 'Erro ao carregar categorias. Por favor, tente novamente mais tarde.';
      }
    );
  }

  carregarProduto(id: number): void {
    this.httpClient.get<ProdutoModel>(`https://localhost:7258/Estoque/produto/${id}`).subscribe(
      (produto) => {
        this.produto = produto;
        // Preenche o formulário com os dados do produto
        this.produtoForm.patchValue({
          nome: produto.nome,
          descricao: produto.descricao,
          preco: produto.preco,
          quantidadeEstoque: produto.quantidadeEstoque,
          dataValidade: this.formatarData(produto.dataValidade),
          idCategoria: produto.idCategoria,
          idFornecedor: produto.idFornecedor
        });
      },
      (error) => {
        console.error('Erro ao carregar produto', error);
        this.mensagemErro = 'Erro ao carregar o produto. Por favor, tente novamente mais tarde.';
      }
    );
  }

  carregarInformacoesCategoria(): void {
    this.httpClient.get<Categoria[]>(`https://localhost:7258/Estoque/categoria`).subscribe(
      (categorias) => {
        // Seleciona a categoria do produto
        const categoriaProduto = categorias.find(c => c.id === this.produto.idCategoria);
        this.produtoForm.patchValue({ idCategoria: categoriaProduto?.id });

        // Adiciona uma verificação para garantir que categoriaProduto?.id não seja undefined
        const categoriaProdutoId = categoriaProduto?.id;
        if (categoriaProdutoId !== undefined) {
          this.carregarFornecedores(categoriaProdutoId);
        }
      },
      (error) => {
        console.error('Erro ao obter informações da categoria', error);
        this.mensagemErro = 'Erro ao obter informações da categoria. Por favor, tente novamente mais tarde.';
      }
    );
  }

  carregarFornecedores(categoriaId: number): void {
    this.httpClient.get<Fornecedor[]>(`https://localhost:7258/Estoque/categoria/InfosFornecedores/${categoriaId}`).subscribe(
      (fornecedores) => {
        this.fornecedores = fornecedores;
        this.produtoForm.patchValue({ idFornecedor: this.fornecedores.length > 0 ? this.fornecedores[0].id : null });
      },
      (error) => {
        console.error('Erro ao obter fornecedores da categoria', error);
        this.mensagemErro = 'Erro ao obter fornecedores da categoria. Por favor, tente novamente mais tarde.';
      }
    );
  }

  atualizarProduto(): void {
    if (this.produtoForm.valid) {
      this.produto.nome = this.produtoForm.value.nome;
      this.produto.descricao = this.produtoForm.value.descricao;
      this.produto.preco = this.produtoForm.value.preco;
      this.produto.quantidadeEstoque = this.produtoForm.value.quantidadeEstoque;
      this.produto.dataValidade = new Date(this.produtoForm.value.dataValidade);
      this.produto.idCategoria = this.produtoForm.value.idCategoria;
      this.produto.idFornecedor = this.produtoForm.value.idFornecedor;

      this.httpClient.put(`https://localhost:7258/Estoque/produto/${this.produto.id}`, this.produto).subscribe(
        () => {
          console.log('Produto atualizado com sucesso!');
          this.mensagemSucesso = 'Produto atualizado com sucesso!';
          this.router.navigate(['/lista-produtos']);
        },
        (error) => {
          console.error('Erro ao atualizar o produto', error);
          this.mensagemErro = 'Erro ao atualizar o produto. Por favor, tente novamente mais tarde.';
        }
      );
    } else {
      this.mensagemErro = 'Por favor, preencha corretamente todos os campos do formulário.';
    }
  }

  private formatarData(data: Date): string {
    return data.toISOString().split('T')[0];
  }
}
