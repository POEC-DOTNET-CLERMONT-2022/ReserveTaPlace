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
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<TheaterDto, TheaterModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Medias, opt => opt.MapFrom(src => src.Medias))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<RoomDto, RoomModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Format))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats))
            .ForMember(dest => dest.TheaterId, opt => opt.MapFrom(src => src.TheaterId));


            CreateMap<NewRoomDto, RoomModel>().ReverseMap();
            CreateMap<NewTheaterDto, TheaterModel>().ReverseMap();
            CreateMap<NewSessionDto, SessionModel>().ReverseMap();


            CreateMap<SeatDto, SeatModel>().ReverseMap();
            CreateMap<FormatDto, FormatModel>().ReverseMap();
            CreateMap<AddressDto, AddressModel>().ReverseMap();
            CreateMap<MediaDto, MediaModel>().ReverseMap();
            CreateMap<RoleDto, RoleModel>().ReverseMap();
            CreateMap<CalendarModel, CalendarDto>().ReverseMap();
            CreateMap<ScheduleDto, ScheduleModel>().ReverseMap();

            CreateMap<SessionDto, SessionModel>().ReverseMap();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
                //.ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                //.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                //.ForMember(dest => dest.CalendarId, opt => opt.MapFrom(src => src.CalendarId));

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

        }
    }
}
