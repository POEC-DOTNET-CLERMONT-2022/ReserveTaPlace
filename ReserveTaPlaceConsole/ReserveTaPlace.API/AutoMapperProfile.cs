using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            //CreateMap<Movie, MovieDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.FirstName));
        }
    }
}
