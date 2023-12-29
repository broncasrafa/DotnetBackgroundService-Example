namespace API.Models.Response;

public class SolicitacaoResponse
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

    public string StatusSolicitacao { get; set; }
    public string StatusProcessamento1 { get; set; }
    public string StatusProcessamento2 { get; set; }
    public string StatusProcessamento3 { get; set; }
}