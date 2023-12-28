﻿using API.Data.Repositories;
using API.Entities;
using API.Models.Request;
using API.Models.Response;
using AutoMapper;

namespace API.Services;

public class SolicitacaoService : ISolicitacaoService
{
    private readonly IMapper _mapper;
    private readonly ISolicitacaoRepository _repository;


    public SolicitacaoService(IMapper mapper, ISolicitacaoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }



    public async Task<SolicitacaoResponse> CreateAsync(SolicitacaoRequest request)
    {
        var solicitacao = new SolicitacaoEntity(request.Documento, request.IdUsuario);
        await _repository.SaveAsync(solicitacao);
        var newData = await _repository.GetByIdAsync(solicitacao.Id);
        var response = _mapper.Map<SolicitacaoResponse>(newData);
        return response;
    }        
    public async Task<SolicitacaoResponse> UpdateAsync(SolicitacaoResponse response)
    {
        var solicitacao = _mapper.Map<SolicitacaoEntity>(response);
        await _repository.UpdateAsync(solicitacao);

        var result = _mapper.Map<SolicitacaoResponse>(solicitacao);
        return result;
    }

    public async Task<IEnumerable<SolicitacaoResponse>> FindAllByUserIdAsync(int userId)
    {
        var data = await _repository.FindAllByUserIdAsync(userId);
        var response = _mapper.Map<IEnumerable<SolicitacaoResponse>>(data);
        return response;
    }
    public async Task<IEnumerable<SolicitacaoResponse>> FindAllByDateNowAsync()
    {
        var data = await _repository.FindAllByDateNowAsync();
        var response = _mapper.Map<IEnumerable<SolicitacaoResponse>>(data);
        return response;
    }
    public async Task<IEnumerable<SolicitacaoResponse>> FindAllRequestedAsync()
    {
        var data = await _repository.FindAllRequestedAsync();
        var response = _mapper.Map<IEnumerable<SolicitacaoResponse>>(data);
        return response;
    }

    public async Task<SolicitacaoResponse> FindByIdAsync(int id)
    {
        var solicitacao = await _repository.GetByIdAsync(id);
        var response = _mapper.Map<SolicitacaoResponse>(solicitacao);
        return response;
    }
}