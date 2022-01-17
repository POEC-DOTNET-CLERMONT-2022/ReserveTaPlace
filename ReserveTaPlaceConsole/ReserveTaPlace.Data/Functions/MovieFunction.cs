using Bogus;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using ReserveTaPlace.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunction : IMovie
    {
        //public Task<IEnumerable<MovieEntity>> GetAll()
        //{
        //    //var id = 0;
        //    //var movie = new Faker<Movie>().CustomInstantiator(f => new Movie(1, f.Random.Replace("###-##-####"))).RuleFor(u => u.Title, (f, u) => f.Name.JobTitle());
        //    //var movies = movie.Generate(5);
        //    //IEnumerable<MovieEntity> moviesList = movies as IEnumerable<MovieEntity>;
        //    //return moviesList;
        //}
        public Task<IEnumerable<MovieEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
