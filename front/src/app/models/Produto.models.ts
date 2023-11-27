import { Categoria} from "./Categoria.models";
import { Fornecedor } from "./Fornecedor.models";
import { FornecedorCategoria } from "./FornecedorCategoria.models";

export interface ProdutoModel {
    id: number;
    nome: string;
    descricao: string;
    preco: number;
    quantidadeEstoque: number;
    dataValidade: Date;
    idFornecedor?: number;
    idCategoria?: number ; 
    fornecedor?: Fornecedor; 
    categoria?: Categoria;
    fornecedorCategoria?: FornecedorCategoria; 
  }