using API.Entities;
using API.Models.Response;

namespace API.Services;

public class My3BackgroundService : BackgroundService
{
    private readonly ILogger<My3BackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public My3BackgroundService(ILogger<My3BackgroundService> logger, IServiceProvider serviceProvider)
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

            var solicitacoesDoDia = await solicitacaoService.FindAllToBeProcessedByService3Async();
            if (solicitacoesDoDia.Count() > 0)
            {
                await ExecutarProcessamento_3_Async(solicitacoesDoDia);
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] Serviço 3 aguardando por novas solicitações....");
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }


    private async Task ExecutarProcessamento_3_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (DataProcessamento_3_Inicio = DateTime.Now, IdStatusProcessamento_3 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();

        _logger.LogInformation($"[{DateTime.Now}] Serviço 3 está executando para o ID: {solicitacao.Id} ....");

        solicitacao.DataInicioProcessamento3 = DateTime.Now;
        solicitacao.IdStatusProcessamento3 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);


        // 2ºfaz oq precisa ser feito
        await Task.Delay(TimeSpan.FromSeconds(8));

        // 3º atualiza a solicitacao (IdStatus = Concluido, DataProcessamento_2_Fim = DateTime.Now, IdStatusProcessamento_2 = Concluido)            
        solicitacao.IdStatus = (int)StatusProcessamento.Concluido;
        solicitacao.DataFimProcessamento3 = DateTime.Now;
        solicitacao.IdStatusProcessamento3 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        _logger.LogInformation($"[{DateTime.Now}] Serviço 3 finalizado para o ID: {solicitacao.Id} ....");

        await Task.CompletedTask;
    }
}