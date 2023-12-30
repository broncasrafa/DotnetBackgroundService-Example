import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Solicitacao } from '../core/models/solicitacao.model';
import { environment } from 'src/environments/environment';
import { SolicitacaoRequest } from '../core/models/solicitacao-request.model';

@Injectable({
  providedIn: 'root'
})
export class SolicitacoesService {

  apiUrl = environment.api_url + '/solicitacoes';

  constructor(private http: HttpClient) { }

  getSolicitacoesUsuario(idUsuario: number): Observable<Solicitacao[]> {
    return this.http.get<Solicitacao[]>(this.apiUrl + '/user/' + idUsuario, { responseType: 'json'})
  }

  processar(request: SolicitacaoRequest): Observable<Solicitacao> {
    return this.http.post<Solicitacao>(this.apiUrl, request);
  }
}
