using Bogus;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunction : IMovie
    {
        public IEnumerable<Movie> GetAllMovies()
        {
            var userIds = 0;
            var movie = new Faker<Movie>().CustomInstantiator(f=> new Movie(f.Name.ToString(), userIds.ToString()));
            var movies = movie.GenerateLazy(5);
            return movies;
        }
    }
}
