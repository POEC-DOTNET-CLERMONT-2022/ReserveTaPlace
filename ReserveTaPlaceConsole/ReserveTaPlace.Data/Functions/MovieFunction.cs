using Bogus;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunction : IMovie
    {
        private DbContext _context;
        public MovieFunction()
        {
            _context = new ReserveTaPlaceContext();
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var id = 0;
            var movie = new Faker<Movie>().CustomInstantiator(f=> new Movie(1,f.Random.Replace("###-##-####"))).RuleFor(u => u.Title, (f, u) => f.Name.JobTitle());
            var movies = movie.Generate(5);
            IEnumerable<Movie> moviesList = movies as IEnumerable<Movie>;
            var newGenre = new GenreEntity();
            var newMovie = new MovieEntity{
                Id = Guid.NewGuid(),
                CastEndDate = "01/01/01",
                CastStartDate = "01/01/01",
                Country = "France",
                IsMovieOnDisplay = false,
                Plot = "test",
                ReleaseDate= "test",
                Runtime = "test",
                Title="Rambo",
                ImdbID="test"
            };
            var newMovieGenre = new MovieGenreEntity();
            newMovieGenre.MovieId = newMovie.Id;
            newGenre.Id = Guid.NewGuid();
            newMovieGenre.GenreId = newGenre.Id;
            newGenre.Name = "Action";
            using (var context = new ReserveTaPlaceContext())
            {
                context.Movies.Add(newMovie);
                context.Genres.Add(newGenre);
                await context.SaveChangesAsync();
                var movieToTest = await context.Movies.FirstOrDefaultAsync(m=>m.Id == newMovie.Id);
                //var genreToTest = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Action");
                
                context.MoviesGenres.Add(newMovieGenre);
                await context.SaveChangesAsync();
                context.Movies.Remove(movieToTest);
                await context.SaveChangesAsync();
            }

            return movies;
        }
    }
}
