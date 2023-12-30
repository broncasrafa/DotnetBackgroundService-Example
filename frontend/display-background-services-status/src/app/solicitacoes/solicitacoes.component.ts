import { Component, OnInit } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeBr from '@angular/common/locales/pt';

import { generateCNPJ } from '../core/utils/generate-cnpj-cpf.util';
import { sortBy } from '../core/utils/common-functions.util';
import { Solicitacao } from '../core/models/solicitacao.model';
import { SolicitacoesService } from './solicitacoes.service';
import { SolicitacaoRequest } from '../core/models/solicitacao-request.model';
import { StatusProcessamento } from '../core/enums/status-processamento.enum';

registerLocaleData(localeBr, 'pt')

@Component({
  selector: 'app-solicitacoes',
  templateUrl: './solicitacoes.component.html',
  styleUrls: ['./solicitacoes.component.css'],
})
export class SolicitacoesComponent implements OnInit {

  document: string = '';
  idUsuario = 86;
  solicitacoes: Solicitacao[] = [];
  

  constructor(private solicitacaoService: SolicitacoesService) { }

  ngOnInit(): void {
    this.getSolicitacoesUsuario();
  }

  getSolicitacoesUsuario() {
    this.solicitacaoService.getSolicitacoesUsuario(this.idUsuario)
      .subscribe((resp: Solicitacao[]) => {
        this.solicitacoes = resp;
      },
      (error) => {
        alert('erro ao obter as solicitacoes do usuario');
      });
      setTimeout(() => this.getSolicitacoesUsuario(), (10 * 1000));
  }

  onClick_gerarCNPJ() {
    const cnpj = generateCNPJ(false);
    this.document = cnpj;
  }

  onClick_processar() {
    var request = {
      idUsuario: this.idUsuario,
      documento: this.document
    } as SolicitacaoRequest;

    this.document = '';
    this.solicitacaoService.processar(request)
      .subscribe((resp: Solicitacao) => {
        if (resp != null && resp !== undefined && resp.id > 0) {
          this.getSolicitacoesUsuario();
        }
      },
      (error) => {
        alert('erro ao realizar a solicitacao');
      })
  }

  setColorStatus(idStatus: number) {
    if (idStatus == StatusProcessamento.Concluido) {
      return "box-concluido";
    }
    if (idStatus == StatusProcessamento.Em_Processamento) {
      return "box-em_processamento";
    }
    if (idStatus == StatusProcessamento.Erro) {
      return "box-erro";
    }
    return "box-default";
  }
}
