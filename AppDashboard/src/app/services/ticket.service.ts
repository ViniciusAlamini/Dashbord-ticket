import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../models/ticket.models';
import { Observable } from 'rxjs';

const httpOptions: Object = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Injectable({
  providedIn: 'root'
})
export class  TicketService {

  url = "http://localhost:5179/api/Ticket"
  
  constructor(private http: HttpClient) {
   }

   BuscarTodos(): Observable<Ticket[]> {
    const apiUrl = `${this.url}/SelecionarTodos`;
    console.log('Buscando todos os tickets...'); // Log para depuração
    return this.http.get<Ticket[]>(apiUrl, httpOptions);
  }  

  BuscarPorId(id: number): Observable<Ticket> {
    const apiUrl = `${this.url}/BuscarPorIdInclude?id=${id}`;
    console.log('Buscando ticket por ID...'); // Log para depuração
    return this.http.get<Ticket>(apiUrl, httpOptions);
  }

  Atualizar(id: number, ticket: Ticket): Observable<Ticket> {
    const apiUrl = `${this.url}/editar`;
    console.log('Atualizando ticket...'); // Log para depuração
    return this.http.put<Ticket>(apiUrl, ticket, httpOptions);
  }
}
