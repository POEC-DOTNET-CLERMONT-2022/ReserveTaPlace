using Bogus;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunctions : IMovie
    {
        public Task<Movie> Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            IEnumerable<Movie> movies;
            using (var context = new ReserveTaPlaceContext())
            {
                movies = await context.Movies.Include(m=>m.Medias).ToListAsync();
            }
            return movies;
        }

        public async Task<Movie> GetById(Guid id)
        {
            var movie = new Movie();
            using (var context = new ReserveTaPlaceContext())
            {
                movie = await context.Movies.FirstOrDefaultAsync(m=>m.Id == id);
            }
            return movie;
        }

        public async Task<Movie> GetByName(string title)
        {
            var movie = new Movie();
            using (var context = new ReserveTaPlaceContext())
            {
                movie = await context.Movies.FirstOrDefaultAsync(m => m.Title.ToLower().StartsWith(title));
            }
            return movie;
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
