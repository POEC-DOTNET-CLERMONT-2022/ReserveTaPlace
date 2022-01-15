using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.Extensions.Factories
{
    public static class MovieFactory
    {

        public static IEnumerable<MovieDto> ToDto(this IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                yield return movie.ToDto();
            }
        }

        public static MovieDto ToDto(this Movie movie)
        {
            return new MovieDto { Title = movie.Title };
        }


        public static IEnumerable<Movie> ToModel(this IEnumerable<MovieDto> movies)
        {
            foreach (var movie in movies)
            {
                yield return movie.ToModel();
            }
        }
        public static Movie ToModel(this MovieDto movie)
        {
            return new Movie(movie.Title, movie.ImdbID);
        }
        public static Movie ToMovie(this ImdbMovie imdbMovie)
        {
            return new Movie(imdbMovie.Title,imdbMovie.ImdbID);
        }

    }
}
