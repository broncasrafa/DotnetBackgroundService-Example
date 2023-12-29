namespace API.Entities;

public class SolicitacaoEntity
{
    public int Id { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public string Documento { get; set; }
    public int IdUsuario { get; set; }
    public int IdStatus { get; set; }

    public DateTime? DataInicioProcessamento1 { get; set; }
    public DateTime? DataInicioProcessamento2 { get; set; }
    public DateTime? DataInicioProcessamento3 { get; set; }

    public DateTime? DataFimProcessamento1 { get; set; }
    public DateTime? DataFimProcessamento2 { get; set; }
    public DateTime? DataFimProcessamento3 { get; set; }

    public int IdStatusProcessamento1 { get; set; }
    public int IdStatusProcessamento2 { get; set; }
    public int IdStatusProcessamento3 { get; set; }

    public virtual StatusEntity StatusSolicitacao { get; set; }
    public virtual StatusEntity StatusProcessamento1 { get; set; }
    public virtual StatusEntity StatusProcessamento2 { get; set; }
    public virtual StatusEntity StatusProcessamento3 { get; set; }

    public SolicitacaoEntity(string documento, int idUsuario)
    {
        Documento = documento;
        IdUsuario = idUsuario;
        DataSolicitacao = DateTime.Now;
        IdStatus = (int)StatusProcessamento.Solicitado;
        IdStatusProcessamento1 = (int)StatusProcessamento.Aguardando_Processamento;
        IdStatusProcessamento2 = (int)StatusProcessamento.Aguardando_Processamento;
        IdStatusProcessamento3 = (int)StatusProcessamento.Aguardando_Processamento;
    }
}

