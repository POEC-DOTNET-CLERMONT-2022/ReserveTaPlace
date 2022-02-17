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
            CreateMap<TheaterDto, TheaterModel>().ReverseMap();
            CreateMap<RoomDto, RoomModel>().ReverseMap();
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
            CreateMap<PaginatedList<MovieDto>, PaginatedList<MovieModel>>().ReverseMap();
            CreateMap<PaginatedList<UserDto>, PaginatedList<UserModel>>().ReverseMap();
        }
    }
}
