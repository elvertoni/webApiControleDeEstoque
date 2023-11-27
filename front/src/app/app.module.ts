// app.module.ts

import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Importe o ReactiveFormsModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './pages/Tarefa/menu/menu/menu.component';
import { FooterComponent } from './pages/Tarefa/Footer/footer/footer.component';
import { FornecedorListarComponent } from './pages/Tarefa/Fornecedor/ListarFornecedor/fornecedor-listar.component';
import { FornecedorCadastrarComponent } from './pages/Tarefa/Fornecedor/CadastrarFornecedor/fornecedor-cadastrar.component';
import { AlterarFornecedorComponent } from './pages/Tarefa/Fornecedor/AlterarFornecedor/alterar-fornecedor.component';
import { CategoriaCadastrarComponent } from './pages/Tarefa/Categoria/CategoriaCadastrar/categoria-cadastrar.component';
import { CategoriaListarComponent } from './pages/Tarefa/Categoria/CategoriaListar/categoria-listar.component';
import { CategoriaAlterarComponent } from './pages/Tarefa/Categoria/CategoriaAlterar/categoria-alterar.component';
import { ProdutoListarComponent } from './pages/Tarefa/Produto/produto-listar/produto-listar.component';
import { ProdutoCadastrarComponent } from './pages/Tarefa/Produto/ProdutoCadastrar/produto-cadastrar/produto-cadastrar.component';
import { ProdutoAlterarComponent } from './pages/Tarefa/Produto/ProdutoAlterar/produto-alterar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';





@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    FornecedorListarComponent,
    FornecedorCadastrarComponent,
    AlterarFornecedorComponent,
    CategoriaCadastrarComponent,
    CategoriaListarComponent,
    CategoriaAlterarComponent,
    ProdutoListarComponent,
    ProdutoCadastrarComponent,
    ProdutoAlterarComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // Adicione o ReactiveFormsModule aos imports
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
