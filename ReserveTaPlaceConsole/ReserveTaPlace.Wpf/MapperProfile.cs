﻿using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;
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
            CreateMap<MovieDto, Movie>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
