// fornecedor-categoria.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FornecedorCategoriaService {
  private apiUrl = 'https://localhost:7258/estoque/FornecedorCategoria';

  constructor(private httpClient: HttpClient) { }

  obterPorCategoria(categoriaId: number): Observable<any[]> {
    const url = `${this.apiUrl}/PorCategoria/${categoriaId}`;
    return this.httpClient.get<any[]>(url).pipe(
      // Certificar-se de que sempre retorna um array
      map(response => Array.isArray(response) ? response : [response])
    );
  }
}
