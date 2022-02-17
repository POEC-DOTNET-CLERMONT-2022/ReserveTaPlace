using AutoMapper;
using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoleEntity, RoleDto>().ReverseMap();
            CreateMap<MovieEntity, MovieDto>().ReverseMap();
            CreateMap<TheaterEntity, NewTheaterDto>().ReverseMap();
            CreateMap<RoomEntity, NewRoomDto>().ReverseMap();
            CreateMap<SeatEntity, SeatDto>().ReverseMap();
            CreateMap<FormatEntity, FormatDto>().ReverseMap();
            CreateMap<AddressEntity, AddressDto>().ReverseMap();
            CreateMap<MediaEntity, MediaDto>().ReverseMap();
            CreateMap<RoleEntity, RoleDto>().ReverseMap();
            CreateMap<CalendarEntity, CalendarDto>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<ScheduleEntity, ScheduleDto>().ReverseMap();
            CreateMap<SessionDto, SessionEntity>().ReverseMap();
            CreateMap<TheaterEntity, TheaterDto>().ReverseMap();
            CreateMap<RoomEntity, RoomDto>().ReverseMap();
            CreateMap<PaginatedList<MovieEntity>, PaginatedList<MovieDto>>().ReverseMap();
            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>().ReverseMap();
            CreateMap<PaginatedList<UserEntity>, PaginatedList<UserDto>>().ReverseMap();

        }
    }
}
