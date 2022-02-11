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
            CreateMap<PaginatedList<UserDto>, PaginatedList<UserModel>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<TheaterDto, TheaterModel>()
                .ForMember(dest => dest.Medias, opt => opt.MapFrom(src => src.Medias));
            CreateMap<RoomDto, RoomModel>().ReverseMap();
            CreateMap<SeatDto, SeatModel>().ReverseMap();
            CreateMap<FormatDto, FormatModel>().ReverseMap();
            CreateMap<AddressDto, AddressModel>().ReverseMap();
            //CreateMap<MediaDto, MediaModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link));
            //CreateMap<MediaModel, MediaDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link));
            CreateMap<MediaDto, MediaModel>().ReverseMap();
            CreateMap<RoleDto, RoleModel>().ReverseMap();
            CreateMap<CalendarModel, CalendarDto>().ReverseMap();
        }
    }
}
