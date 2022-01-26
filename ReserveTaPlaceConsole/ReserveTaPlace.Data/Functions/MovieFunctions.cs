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
        private DbContext _dbContext;
        public MovieFunctions(DbContext context)
        {
            _dbContext = context;
            _movies= new List<MovieEntity>();
        }

        public async Task<bool> Add(MovieEntity movieEntity)
        {
            using (_dbContext)
            {
                await _dbContext.Set<MovieEntity>().AddAsync(movieEntity);
                var result= await _dbContext.SaveChangesAsync();
                return result > 0;
            }
        }

        public async Task<bool> DeleteById(Guid id)
        {
            int result = 0;
            using (_dbContext)
            {
                var entity = await _dbContext.Set<MovieEntity>().FirstOrDefaultAsync(u => u.Id == id);
                _dbContext.Set<MovieEntity>().Remove(entity);
                result = await _dbContext.SaveChangesAsync();
            };
            return result == 1;
        }

        public async Task<IEnumerable<MovieEntity>> GetAll()
        {
            _movies = await _dbContext.Set<MovieEntity>().Include(m => m.Medias).ToListAsync();
            return _movies;
        }

        public async Task<MovieEntity> GetById(Guid id)
        {
            var movie = new MovieEntity();
            movie = await _dbContext.Set<MovieEntity>().FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<MovieEntity> GetByName(string title)
        {
            var movie = new MovieEntity();
            movie = await _dbContext.Set<MovieEntity>().FirstOrDefaultAsync(m => m.Title.ToLower().StartsWith(title));
            return movie;
        }
    }
}
