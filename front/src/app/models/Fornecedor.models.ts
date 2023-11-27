
export interface Fornecedor {
    id: number;
    nome: string;
    endereco: string;
    telefone: string;
    cnpj: string;
    fornecedorCategoria: FornecedorCategoria[];
  }
  
  export interface FornecedorCategoria {
    id: number;
    fornecedorId: number;
    categoriaId: number;
  }