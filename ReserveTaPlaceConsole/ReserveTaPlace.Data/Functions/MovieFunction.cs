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
        public async Task<IEnumerable<Models.Movie>> GetAllMovies()
        {
            var id = 0;
            var movie = new Faker<Models.Movie>().CustomInstantiator(f=> new Models.Movie(1, f.Random.Replace("###-##-####"))).RuleFor(u => u.Title, (f, u) => f.Name.JobTitle());
            var movies = movie.Generate(5);
            IEnumerable<Models.Movie> moviesList = movies as IEnumerable<Models.Movie>;

            //using (var context = new ReserveTaPlaceContext())
            //{
            //    var genre = new Genre { Id = Guid.NewGuid(), Name = "Action" };
            //    var movietest = new Entities.Movie { Id = Guid.NewGuid(),
            //        CastEndDate = DateTime.Now.ToString(),
            //        CastStartDate = DateTime.Now.ToString(),
            //        Country = "France",
            //        ImdbID = "tt154879",
            //        IsMovieOnDisplay = true,
            //        Plot = "blablabla",
            //        ReleaseDate = DateTime.Now.ToString(),
            //        Runtime = "1H50",
            //        Title = "Rambo II"
            //        };
            //    context.Genres.Add(genre);
            //    await context.SaveChangesAsync();
            //    var genretest = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Action");
            //    movietest.Genres.Add(genretest);
            //    context.Movies.Add(movietest);
            //    await context.SaveChangesAsync();
            //}
            using (var context = new ReserveTaPlaceContext())
            {
                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    City = "Clermont-Ferrand",
                    PostalCode = "63000",
                    County = "Puy de Dôme"
                };
                var theater = new Theater
                {
                    Id = Guid.NewGuid(),
                    Name = "CinéDôme",
                    Address = address,
                };
                //var room1 = new Room
                //{
                //    Id = Guid.NewGuid(),
                //    Number = "1",
                //    Theater = theater
                //};
                //var room2 = new Room
                //{
                //    Id = Guid.NewGuid(),
                //    Number = "2",
                //    Theater = theater
                //};
                //var seatA1 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "A",
                //    Number = "1",
                //};
                //var seatA2 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "A",
                //    Number = "2",
                //};
                //var seatA3 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "A",
                //    Number = "3",
                //};
                //var seatA4 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "A",
                //    Number = "4",
                //};
                //var seatB1 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "B",
                //    Number = "1",
                //};
                //var seatB2 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "B",
                //    Number = "2",
                //};
                //var seatB3 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "B",
                //    Number = "3",
                //};
                //var seatB4 = new Seat
                //{
                //    Id = Guid.NewGuid(),
                //    Row = "B",
                //    Number = "4",
                //};
                //context.Theaters.Add(theater);
                //await context.SaveChangesAsync();
                var theatertest = await context.Theaters.Include(t => t.Address).SingleOrDefaultAsync(t => t.Name == "CinéDôme");
                context.Theaters.Remove(theatertest);
                context.Address.Remove(theatertest.Address);
                await context.SaveChangesAsync();

            }
            return movies;
        }
    }
}
