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
            //Todo Implémenter flattened DTOS https://enroute.osgi.org/FAQ/420-dtos.html
            CreateMap<MovieEntity, MovieDto>().ReverseMap();

            //CreateMap<MovieEntity, MovieDto>().ReverseMap();
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

            //CreateMap<List<SessionEntity>, List<SessionDto>>().ReverseMap();

            CreateMap<SessionDto, SessionEntity>().ReverseMap();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
                //.ForMember(dest => dest.Calendar, opt => opt.MapFrom(src => src.Calendar))
                //.ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                //.ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room))
                //.ForMember(dest => dest.CalendarId, opt => opt.MapFrom(src => src.Calendar.Id))
                //.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.Id))
                //.ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Movie.Id));


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
            CreateMap<PaginatedList<MovieEntity>, PaginatedList<MovieDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
            CreateMap<PaginatedList<UserEntity>, PaginatedList<UserDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
