namespace API.Entities;

public class StatusEntity
{
    public int Id { get; }
    public string Descricao { get; }
}

public enum StatusProcessamento
{
    Solicitado = 1,
    Aguardando_Processamento = 2,
    Em_Processamento = 3,
    Concluido = 4,
    Nao_Executado = 5,
    Erro = 6
}