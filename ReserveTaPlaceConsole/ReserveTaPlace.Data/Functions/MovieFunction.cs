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
            var id = 0;
            var movie = new Faker<Movie>().CustomInstantiator(f=> new Movie(1,f.Random.Replace("###-##-####"))).RuleFor(u => u.Title, (f, u) => f.Name.JobTitle());
            var movies = movie.Generate(5);
            IEnumerable<Movie> moviesList = movies as IEnumerable<Movie>;
            return movies;
        }
    }
}
