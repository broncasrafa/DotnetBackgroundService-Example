using API.Entities;
using API.Models.Response;
using AutoMapper;

namespace API.Models.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SolicitacaoResponse, SolicitacaoEntity>();
        CreateMap<SolicitacaoEntity, SolicitacaoResponse>()
            .ForMember(dest => dest.StatusSolicitacao, from => from.MapFrom(src => src.StatusSolicitacao.Descricao))
            .ForMember(dest => dest.StatusProcessamento1, from => from.MapFrom(src => src.StatusProcessamento1.Descricao))
            .ForMember(dest => dest.StatusProcessamento2, from => from.MapFrom(src => src.StatusProcessamento2.Descricao))
            .ForMember(dest => dest.StatusProcessamento3, from => from.MapFrom(src => src.StatusProcessamento3.Descricao));
    }
}