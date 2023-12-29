using API.Entities;
using API.Models.Response;

namespace API.Services;

public class My1BackgroundService : BackgroundService
{
    private readonly ILogger<My1BackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;    

    public My1BackgroundService(ILogger<My1BackgroundService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }



    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // fica no loop infinito
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

            var solicitacoesDoDia = await solicitacaoService.FindAllToBeProcessedByService1Async();
            if (solicitacoesDoDia.Count() > 0)
            {
                await ExecutarProcessamento_1_Async(solicitacoesDoDia);
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] 👉🏾 Serviço 1 aguardando por novas solicitações....");
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }


    private async Task ExecutarProcessamento_1_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (IdStatus = Em Processamento, DataProcessamento_1_Inicio = DateTime.Now, IdStatusProcessamento_1 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();

        _logger.LogInformation($"[{DateTime.Now}] ♥️ Serviço 1 está executando para o ID: {solicitacao.Id} ....");

        solicitacao.IdStatus = (int)StatusProcessamento.Em_Processamento;
        solicitacao.DataInicioProcessamento1 = DateTime.Now;
        solicitacao.IdStatusProcessamento1 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);

        // 2ºfaz oq precisa ser feito
        await Task.Delay(TimeSpan.FromSeconds(5));

        // 3º atualiza a solicitacao (IdStatus = Em Processamento, DataProcessamento_1_Fim = DateTime.Now, IdStatusProcessamento_1 = Concluido)            
        solicitacao.DataFimProcessamento1 = DateTime.Now;
        solicitacao.IdStatusProcessamento1 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        _logger.LogInformation($"[{DateTime.Now}] ✅ Serviço 1 finalizado para o ID: {solicitacao.Id} ....");

        await Task.CompletedTask;
    }
}