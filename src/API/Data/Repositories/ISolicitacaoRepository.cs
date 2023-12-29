using System.Linq.Expressions;
using API.Entities;
using API.Models.Response;

namespace API.Data.Repositories;

public interface ISolicitacaoRepository
{

    Task<IEnumerable<SolicitacaoEntity>> FindAllByUserIdAsync(int userId);
    Task<IEnumerable<SolicitacaoEntity>> FindAllByDateNowAsync();
    Task<IEnumerable<SolicitacaoEntity>> FindAllRequestedAsync();
    //Task<IEnumerable<SolicitacaoEntity>> FindAllByCriteriaAsync(Expression<Func<SolicitacaoEntity, bool>> predicate);
    Task<SolicitacaoEntity> GetByIdAsync(int id);
    Task<SolicitacaoEntity> SaveAsync(SolicitacaoEntity solicitacao);
    Task<SolicitacaoEntity> UpdateAsync(SolicitacaoEntity solicitacao);
}