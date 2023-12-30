import { Component, Input, OnInit } from '@angular/core';
import { StatusProcessamento } from 'src/app/core/enums/status-processamento.enum';

@Component({
  selector: 'app-box-status-icon',
  templateUrl: './box-status-icon.component.html',
  styleUrls: ['./box-status-icon.component.css'],
})
export class BoxStatusIconComponent implements OnInit {

  @Input() idStatus: number;
  statusSolicitacaoEnum = StatusProcessamento;
  
  constructor() { }

  ngOnInit(): void {
  }

}
