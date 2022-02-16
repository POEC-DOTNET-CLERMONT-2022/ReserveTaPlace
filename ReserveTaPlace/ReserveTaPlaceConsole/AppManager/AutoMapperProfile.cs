using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models.CModels;

namespace ReserveTaPlace.CAPP.AppManager
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();

        }
    }
}
