using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieEntity, MovieDto>().ReverseMap();
            CreateMap<MovieEntity, Movie>().ReverseMap();
            //CreateMap<Movie, MovieDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.FirstName));
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
