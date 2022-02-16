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
            //TODO : pas besoin ? 
            CreateMap<TheaterEntity, TheaterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Medias, opt => opt.MapFrom(src => src.Medias))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms));
            CreateMap<RoomEntity, RoomDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TheaterId, opt => opt.MapFrom(src => src.TheaterId))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Format))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number));
            CreateMap<PaginatedList<MovieEntity>, PaginatedList<MovieDto>>().ReverseMap();

            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>().ReverseMap();

            CreateMap<PaginatedList<UserEntity>, PaginatedList<UserDto>>().ReverseMap();

        }
    }
}
