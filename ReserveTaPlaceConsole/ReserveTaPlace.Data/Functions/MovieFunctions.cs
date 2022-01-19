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
        private IEnumerable<MovieEntity> _movies;
        private string _connectionString;
        public MovieFunctions(string connectionString)
        {
            _connectionString = connectionString;
            _movies= new List<MovieEntity>();
        }

        public async Task<MovieEntity> Add(MovieEntity movieEntity)
        {
            using (var context = new ReserveTaPlaceContext(_connectionString))
            {
                await context.Movies.AddAsync(movieEntity);
                await context.SaveChangesAsync();
            }
            return movieEntity;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            int result = 0;
            using (var context = new ReserveTaPlaceContext(_connectionString))
            {
                var entity = await context.Movies.FirstOrDefaultAsync(u => u.Id == id);
                context.Movies.Remove(entity);
                result = await context.SaveChangesAsync();
            };
            return result == 1;
        }

        public async Task<IEnumerable<MovieEntity>> GetAll()
        {
            using (var context = new ReserveTaPlaceContext())
            {
                _movies = await context.Movies.Include(m => m.Medias).ToListAsync();
            }
            return _movies;
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
    }
}
