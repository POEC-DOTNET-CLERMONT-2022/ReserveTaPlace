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
            //Todo Implémenter flattened DTOS https://enroute.osgi.org/FAQ/420-dtos.html
            CreateMap<MovieEntity, MovieDto>().ReverseMap();
            CreateMap<MovieEntity, Movie>().ReverseMap();
            //CreateMap<MovieEntity, MovieDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.FirstName));
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserDto>()
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src =>src.Email))
              .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Theaters, opt => opt.MapFrom(src => src.Theaters))
              .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
        }
    }
}
