using AutoMapper;
using CinemaAPI.Data.Dtos.Filme;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {           
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
