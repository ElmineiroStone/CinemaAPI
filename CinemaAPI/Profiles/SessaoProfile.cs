using AutoMapper;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles
{
    public class SessaoProfile: Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(sessaoDto => sessaoDto.HorarioDeInicio, opts => opts
                .MapFrom(sessaoDto =>
                sessaoDto.HorarioDeEncerramento.AddMinutes(sessaoDto.Filme.Duracao * (1))));

        }
    }
}
    