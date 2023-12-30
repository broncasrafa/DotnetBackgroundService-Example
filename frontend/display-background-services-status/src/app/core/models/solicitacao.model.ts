export class Solicitacao {
    id: number;
    dataSolicitacao: string;
    documento: string;
    idUsuario: number;
    idStatus: number;
    dataInicioProcessamento1?: string;
    dataInicioProcessamento2?: string;
    dataInicioProcessamento3?: string;
    dataFimProcessamento1?: string;
    dataFimProcessamento2?: string;
    dataFimProcessamento3?: string;
    idStatusProcessamento1: number;
    idStatusProcessamento2: number;
    idStatusProcessamento3: number;
    statusSolicitacao: string;
    statusProcessamento1: string;
    statusProcessamento2: string;
    statusProcessamento3: string;
  }