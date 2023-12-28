using API.Entities;
using API.Models.Response;
using AutoMapper;

namespace API.Services;

public class MyBackgroundService : BackgroundService
{
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<MyBackgroundService> _logger;


    public MyBackgroundService(ILogger<MyBackgroundService> logger, IMapper mapper, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mapper = mapper;
        _serviceProvider = serviceProvider;
    }



    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // fica no loop infinito
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

            var solicitacoesDoDia = await solicitacaoService.FindAllRequestedAsync();
            if (solicitacoesDoDia.Count() > 0)
            {
                //System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Executando novas solicitações....");
                _logger.LogInformation($"[{DateTime.Now}] Executando novas solicitações....");

                await ExecutarProcessamento_1_Async(solicitacoesDoDia);
                await ExecutarProcessamento_2_Async(solicitacoesDoDia);
                await ExecutarProcessamento_3_Async(solicitacoesDoDia);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Aguardando por novas solicitações....");
                _logger.LogInformation($"[{DateTime.Now}] Aguardando por novas solicitações....");
            }
        }
    }


    private async Task ExecutarProcessamento_1_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (IdStatus = Em Processamento, DataProcessamento_1_Inicio = DateTime.Now, IdStatusProcessamento_1 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();
        solicitacao.IdStatus = (int)StatusProcessamento.Em_Processamento;
        solicitacao.DataInicioProcessamento1 = DateTime.Now;
        solicitacao.IdStatusProcessamento1 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);



        // 2ºfaz oq precisa ser feito
        Thread.Sleep(TimeSpan.FromSeconds(5));

        // 3º atualiza a solicitacao (IdStatus = Em Processamento, DataProcessamento_1_Fim = DateTime.Now, IdStatusProcessamento_1 = Concluido)            
        solicitacao.DataFimProcessamento1 = DateTime.Now;
        solicitacao.IdStatusProcessamento1 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        await Task.CompletedTask;
    }

    private async Task ExecutarProcessamento_2_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (DataProcessamento_2_Inicio = DateTime.Now, IdStatusProcessamento_2 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();
        solicitacao.DataInicioProcessamento2 = DateTime.Now;
        solicitacao.IdStatusProcessamento2 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);



        // 2ºfaz oq precisa ser feito
        Thread.Sleep(TimeSpan.FromSeconds(5));

        // 3º atualiza a solicitacao (DataProcessamento_2_Fim = DateTime.Now, IdStatusProcessamento_2 = Concluido)            
        solicitacao.DataFimProcessamento2 = DateTime.Now;
        solicitacao.IdStatusProcessamento2 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        await Task.CompletedTask;
    }

    private async Task ExecutarProcessamento_3_Async(IEnumerable<SolicitacaoResponse> solicitacoesDoDia)
    {
        using var scope = _serviceProvider.CreateScope();
        var solicitacaoService = scope.ServiceProvider.GetService<ISolicitacaoService>();

        // 1º atualiza a solicitacao (DataProcessamento_3_Inicio = DateTime.Now, IdStatusProcessamento_3 = Em Processamento)
        var solicitacao = solicitacoesDoDia.FirstOrDefault();
        solicitacao.DataInicioProcessamento3 = DateTime.Now;
        solicitacao.IdStatusProcessamento3 = (int)StatusProcessamento.Em_Processamento;
        await solicitacaoService.UpdateAsync(solicitacao);



        // 2ºfaz oq precisa ser feito
        Thread.Sleep(TimeSpan.FromSeconds(5));

        // 3º atualiza a solicitacao (IdStatus = Concluido, DataProcessamento_2_Fim = DateTime.Now, IdStatusProcessamento_2 = Concluido)            
        solicitacao.IdStatus = (int)StatusProcessamento.Concluido;
        solicitacao.DataFimProcessamento3 = DateTime.Now;
        solicitacao.IdStatusProcessamento3 = (int)StatusProcessamento.Concluido;
        await solicitacaoService.UpdateAsync(solicitacao);

        await Task.CompletedTask;
    }
}