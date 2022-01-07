﻿using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.MovieDataBaseService
{
    public interface IMovieProvider
    {
        Task<Movie> GetMovie(string movie, string year);
    }
}