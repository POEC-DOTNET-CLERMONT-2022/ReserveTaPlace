using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReserveTaPlace.Wpf
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MovieDto, MovieModel>().ReverseMap();
            CreateMap<PaginatedList<MovieDto>, PaginatedList<MovieModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
