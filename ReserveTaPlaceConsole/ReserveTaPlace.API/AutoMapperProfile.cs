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
            //CreateMap(typeof(PaginatedList<MovieEntity>), typeof(PaginatedList<MovieModel>));
            CreateMap<PaginatedList<MovieEntity>, PaginatedList<MovieDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));

            //CreateMap<MovieEntity, MovieDto>().ForMember(dest => dest.Name, src => src.MapFrom(src => src.FirstName));
            CreateMap<UserEntity, UserDto>().ReverseMap();
            //CreateMap<UserEntity, UserDto>()
            //  .ForMember(dest => dest.Email, opt => opt.MapFrom(src =>src.Email))
            //  .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.FirstName))
            //  .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.LastName))
            //  .ForMember(dest => dest.Theaters, opt => opt.MapFrom(src => src.Theaters))
            //  .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
            CreateMap<TheaterEntity, TheaterDto>().ReverseMap();
            CreateMap<RoomEntity, RoomDto>().ReverseMap();
            CreateMap<SeatEntity, SeatDto>().ReverseMap();
            CreateMap<FormatEntity, FormatDto>().ReverseMap();
            //CreateMap<TheaterEntity, TheaterDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
            //    .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
            //    .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
            CreateMap<PaginatedList<TheaterEntity>, PaginatedList<TheaterDto>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.HasNextPage, opt => opt.MapFrom(src => src.HasNextPage))
                .ForMember(dest => dest.HasPreviousPage, opt => opt.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.PageIndex, opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));
        }
    }
}
