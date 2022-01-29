using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;
using System.Collections.Generic;

namespace ReserveTaPlace.Extensions.Factories
{
    public static class MovieFactory
    {

        public static IEnumerable<MovieDto> ToDto(this IEnumerable<MovieModel> movies)
        {
            foreach (var movie in movies)
            {
                yield return movie.ToDto();
            }
        }

        public static MovieDto ToDto(this MovieModel movie)
        {
            return new MovieDto { Title = movie.Title };
        }


        public static IEnumerable<MovieModel> ToModel(this IEnumerable<MovieDto> movies)
        {
            foreach (var movie in movies)
            {
                yield return movie.ToModel();
            }
        }
        public static MovieModel ToModel(this MovieDto movie)
        {
            return new MovieModel(movie.Title, movie.Plot, movie.Genre, movie.Director, movie.Poster, movie.ImdbId,movie.Released,movie.Runtime);
        }
        //public static Movie ToMovie(this ImdbMovie imdbMovie)
        //{
        //    return new Movie(imdbMovie.Title, imdbMovie.Plot, imdbMovie.Poster, imdbMovie.ImdbId, imdbMovie.ReleaseDate, imdbMovie.Runtime);
        //}

    }
}
