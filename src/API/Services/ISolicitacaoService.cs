using API.Models.Request;
using API.Models.Response;

namespace API.Services;

public interface ISolicitacaoService
{
    Task<SolicitacaoResponse> CreateAsync(SolicitacaoRequest request);
    Task<SolicitacaoResponse> UpdateAsync(SolicitacaoResponse request);
    Task<SolicitacaoResponse> FindByIdAsync(int id);
    Task<IEnumerable<SolicitacaoResponse>> FindAllByUserIdAsync(int userId);
    Task<IEnumerable<SolicitacaoResponse>> FindAllByDateNowAsync();
    Task<IEnumerable<SolicitacaoResponse>> FindAllRequestedAsync();
    
    Task<IEnumerable<SolicitacaoResponse>> FindAllToBeProcessedByService1Async();
    Task<IEnumerable<SolicitacaoResponse>> FindAllToBeProcessedByService2Async();
    Task<IEnumerable<SolicitacaoResponse>> FindAllToBeProcessedByService3Async();
}