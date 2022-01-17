using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunctions : IMovie
    {
        public Task<MovieEntity> Add(MovieEntity movie)
        {
            throw new NotImplementedException();
        }

        public Task<MovieEntity> Delete(MovieEntity movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieEntity>> GetAll()
        {
            IEnumerable<MovieEntity> movies;
            using (var context = new ReserveTaPlaceContext())
            {
                movies = await context.Movies.Include(m => m.Medias).ToListAsync();
            }
            return movies;
        }

        public async Task<MovieEntity> GetById(Guid id)
        {
            var movie = new MovieEntity();
            using (var context = new ReserveTaPlaceContext())
            {
                movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            }
            return movie;
        }

        public async Task<MovieEntity> GetByName(string title)
        {
            var movie = new MovieEntity();
            using (var context = new ReserveTaPlaceContext())
            {
                movie = await context.Movies.FirstOrDefaultAsync(m => m.Title.ToLower().StartsWith(title));
            }
            return movie;
        }

        public Task<MovieEntity> Update(MovieEntity movie)
        {
            throw new NotImplementedException();
        }
    }
}
