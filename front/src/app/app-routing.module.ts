// app-routing.module.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FornecedorListarComponent } from './pages/Tarefa/Fornecedor/ListarFornecedor/fornecedor-listar.component'; 
import { FornecedorCadastrarComponent } from './pages/Tarefa/Fornecedor/CadastrarFornecedor/fornecedor-cadastrar.component';
import { AlterarFornecedorComponent } from './pages/Tarefa/Fornecedor/AlterarFornecedor/alterar-fornecedor.component';
import { CategoriaCadastrarComponent } from './pages/Tarefa/Categoria/CategoriaCadastrar/categoria-cadastrar.component';
import { CategoriaListarComponent } from './pages/Tarefa/Categoria/CategoriaListar/categoria-listar.component';
import { CategoriaAlterarComponent } from './pages/Tarefa/Categoria/CategoriaAlterar/categoria-alterar.component';
import { ProdutoListarComponent } from './pages/Tarefa/Produto/produto-listar/produto-listar.component';
import { ProdutoCadastrarComponent } from './pages/Tarefa/Produto/ProdutoCadastrar/produto-cadastrar/produto-cadastrar.component';
import { ProdutoAlterarComponent } from './pages/Tarefa/Produto/ProdutoAlterar/produto-alterar.component';





const routes: Routes = [
  { path: '', component: FornecedorListarComponent },
  { path: 'listar-fornecedores', component: FornecedorListarComponent },
  { path: 'cadastrar-fornecedores', component: FornecedorCadastrarComponent },
  { path: 'alterar-fornecedor/:id', component: AlterarFornecedorComponent },
  { path: 'cadastrar-categoria', component: CategoriaCadastrarComponent },
  { path: 'listar-categoria', component: CategoriaListarComponent },
  { path: 'alterar-categoria/:id', component: CategoriaAlterarComponent},
  { path: 'produto-listar', component: ProdutoListarComponent},
  { path: 'produto-cadastrar', component: ProdutoCadastrarComponent},
  { path: 'produto-alterar/:id', component: ProdutoAlterarComponent}

  
  
  // Adicione mais rotas conforme necessário
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
