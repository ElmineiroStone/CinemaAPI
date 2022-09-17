using AutoMapper;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles
{
    public class GerenteProfile:Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente,ReadGerenteDto>()
                .ForMember(Gerente => Gerente.Cinemas, opt => opt
                .MapFrom(Gerente => Gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
