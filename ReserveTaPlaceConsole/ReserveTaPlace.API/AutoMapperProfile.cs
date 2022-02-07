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

            CreateMap<MovieEntity, MovieModel>().ReverseMap();

            CreateMap<PaginatedList<MovieEntity>, PaginatedList<MovieDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));

            CreateMap<UserEntity, UserDto>()
                .ForMember(dto => dto.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(u => u.LastName))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(u => u.FirstName))
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role).ToList()))
                .ForMember(dto => dto.Discounts, opt => opt.MapFrom(u => u.Discounts))
                .ForMember(dto => dto.Orders, opt => opt.MapFrom(u => u.Orders));

            CreateMap<TheaterEntity, TheaterDto>()
                //.ForMember(dto => dto.Users, opt => opt.MapFrom(t => t.TheaterUsers.Select(ut => ut.User).ToList()))
                .ForMember(dto => dto.Rooms, opt => opt.MapFrom(t => t.Rooms))
                .ForMember(dto => dto.Medias, opt => opt.MapFrom(t => t.Medias))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(t => t.Address))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(t => t.Name));

            CreateMap<RoomEntity, RoomDto>()
                .ForMember(dto => dto.Seats, opt => opt.MapFrom(r => r.RoomSeats.Select(rs => rs.Seat).ToList()))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(r => r.Number))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(r => r.Id))
                .ForMember(dto => dto.Sessions, opt => opt.MapFrom(r => r.Sessions))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(r => r.Name));


            CreateMap<SeatEntity, SeatDto>().ReverseMap();
            CreateMap<FormatEntity, FormatDto>().ReverseMap();
            CreateMap<AddressEntity, AddressDto>().ReverseMap();
            CreateMap<MediaEntity, MediaDto>().ReverseMap();

            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
