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

            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<TheaterEntity, TheaterDto>().ReverseMap();
            CreateMap<RoomEntity, RoomDto>().ReverseMap();
            CreateMap<SeatEntity, SeatDto>().ReverseMap();
            CreateMap<FormatEntity, FormatDto>().ReverseMap();
            CreateMap<AddressEntity, AddressDto>().ReverseMap();
            CreateMap<MediaEntity, MediaDto>().ReverseMap();
            CreateMap<RoleEntity, RoleDto>().ReverseMap();

            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
