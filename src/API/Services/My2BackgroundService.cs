using API.Entities;
using API.Models.Response;

namespace API.Services;

public class My2BackgroundService : BackgroundService
{
    private readonly ILogger<My2BackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public My2BackgroundService(ILogger<My2BackgroundService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }



    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

            var solicitacoesDoDia = await solicitacaoService.FindAllToBeProcessedByService2Async();
            if (solicitacoesDoDia.Count() > 0)
            {                    
                await ExecutarProcessamento_2_Async(solicitacoesDoDia);
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] Serviço 2 aguardando por novas solicitações....");
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }
    }


    private async Task ExecutarProcessamento_2_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (DataProcessamento_2_Inicio = DateTime.Now, IdStatusProcessamento_2 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();
        
        _logger.LogInformation($"[{DateTime.Now}] Serviço 2 está executando para o ID: {solicitacao.Id} ....");

        solicitacao.DataInicioProcessamento2 = DateTime.Now;
        solicitacao.IdStatusProcessamento2 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);

        // 2º faz oq precisa ser feito
        await Task.Delay(TimeSpan.FromSeconds(6));

        // 3º atualiza a solicitacao (DataProcessamento_2_Fim = DateTime.Now, IdStatusProcessamento_2 = Concluido)            
        solicitacao.DataFimProcessamento2 = DateTime.Now;
        solicitacao.IdStatusProcessamento2 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        _logger.LogInformation($"[{DateTime.Now}] Serviço 2 finalizado para o ID: {solicitacao.Id} ....");

        await Task.CompletedTask;
    }
}