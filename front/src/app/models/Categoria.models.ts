export interface Categoria {
  id: number;
  nome: string;
  descricao: string;
  fornecedorIds: number[]; // ou pode ser null dependendo dos requisitos
  fornecedores: Fornecedor[]; // Adicionada esta propriedade
}

export interface FornecedorCategoria {
  id: number;
  fornecedorId: number;
  categoriaId: number;
}

export interface Fornecedor {
  id: number;
  nome: string;
  cnpj: string;
}