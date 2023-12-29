using System;
using API.Data.Context;
using API.Entities;
using API.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class SolicitacaoRepository : ISolicitacaoRepository
{
    private readonly ApplicationDbContext _context;

    public SolicitacaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<SolicitacaoEntity>> FindAllByUserIdAsync(int userId)
    {
        var list = await _context.Solicitacoes
            .AsNoTracking()
            .Include(c => c.StatusSolicitacao)
            .Include(c => c.StatusProcessamento1)
            .Include(c => c.StatusProcessamento2)
            .Include(c => c.StatusProcessamento3)
            .Where(c => c.IdUsuario == userId)
            .ToListAsync();
        return list;
    }
    public async Task<IEnumerable<SolicitacaoEntity>> FindAllByDateNowAsync()
    {
        var list = await _context.Solicitacoes
            .AsNoTracking()
            .Where(c => c.DataSolicitacao.Date == DateTime.Now.Date)
            .ToListAsync();
        return list;
    }
    public async Task<IEnumerable<SolicitacaoEntity>> FindAllRequestedAsync()
    {
        var list = await _context.Solicitacoes
            .AsNoTracking()
            .Where(c => c.DataSolicitacao.Date == DateTime.Now.Date && 
                        c.IdStatus == (int)StatusProcessamento.Solicitado && 
                        c.IdStatusProcessamento1 == (int)StatusProcessamento.Aguardando_Processamento)
            .ToListAsync();
        return list;
    }

    public async Task<SolicitacaoEntity> GetByIdAsync(int id)
    {
        return await _context.Solicitacoes
            .AsNoTracking()
            .Include(c => c.StatusSolicitacao)
            .Include(c => c.StatusProcessamento1)
            .Include(c => c.StatusProcessamento2)
            .Include(c => c.StatusProcessamento3)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<SolicitacaoEntity> SaveAsync(SolicitacaoEntity solicitacao)
    {
        await _context.Solicitacoes.AddAsync(solicitacao);
        await _context.SaveChangesAsync();
        return solicitacao;
    }

    public async Task<SolicitacaoEntity> UpdateAsync(SolicitacaoEntity solicitacao)
    {
        try
        {
            //_context.Attach(solicitacao);
            _context.Entry(solicitacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(solicitacao).State = EntityState.Detached;
            return solicitacao;
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }
}