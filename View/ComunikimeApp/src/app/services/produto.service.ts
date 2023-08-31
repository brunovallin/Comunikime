import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root',
})
export class ProdutoService {
  baseApi = 'https://localhost:5001/api/produto';
  constructor(private http:HttpClient) {}

  public getProdutos():Observable<Produto[]>{
    return this.http.get<Produto[]>(this.baseApi)
  }

  public getProdutosbyDescricao(descricao:string):Observable<Produto[]>{
    return this.http.get<Produto[]>(`${this.baseApi}/${descricao}/descricao`);
  }

  public getProdutoById(id:number):Observable<Produto>{
    return this.http.get<Produto>(`${this.baseApi}/${id}`)
  }

  public postProduto(produto:Produto):Observable<Produto>{
    return this.http.post<Produto>(this.baseApi,produto);
  }

  public putProduto(id:number,produto:Produto):Observable<Produto>{
    return this.http.put<Produto>(`${this.baseApi}/${id}`,produto);
  }

  public deleteProduto(id:number):Observable<any>{
    return this.http.delete<string>(`${this.baseApi}/${id}`)
  }
}
