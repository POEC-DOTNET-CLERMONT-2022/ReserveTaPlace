using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Data.Utils;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class TheaterFunctions : ITheater
    {
        private IEnumerable<TheaterEntity> _theaters;
        private DbContext _dbContext;
        public TheaterFunctions(DbContext context)
        {
            _dbContext = context;
            _theaters = new List<TheaterEntity>();
        }
        public async Task<bool> Add(TheaterEntity theaterEntity)
        {
            await _dbContext.Set<TheaterEntity>().AddAsync(theaterEntity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var entity = await _dbContext.Set<TheaterEntity>()
                .Include(t => t.Address)
                .Include(t => t.Rooms)
                .Include(t => t.Medias)
                .FirstOrDefaultAsync(t => t.Id == id);
            _dbContext.Set<TheaterEntity>().Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<IEnumerable<TheaterEntity>> GetAll()
        {
            _theaters = await _dbContext.Set<TheaterEntity>()
                .Include(t => t.Address)
                .Include(t => t.Rooms).ThenInclude(r => r.Format)
                .Include(t => t.Rooms).ThenInclude(r => r.Seats).ThenInclude(r => r.Schedules).ThenInclude(r => r.Sessions)
                .Include(t => t.Medias)
                .Include(t => t.Users).ThenInclude(u => u.Roles)

                .ToListAsync();
            return _theaters;
        }

        public async Task<PaginatedList<TheaterEntity>> GetAllPaginated(int pageIndex, int pageSize)
        {
            return await PaginatedList<TheaterEntity>.CreateAsync(_dbContext.Set<TheaterEntity>(), pageIndex, pageSize);
        }

        public async Task<TheaterEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TheaterEntity>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TheaterEntity> GetByName(string name)
        {
            return await _dbContext.Set<TheaterEntity>().FirstOrDefaultAsync(t => t.Name.ToLower().StartsWith(name));
        }

        public async Task<TheaterEntity> Update(TheaterEntity theaterEntity)
        {
            if(theaterEntity != null)
            {
                _dbContext.Update(theaterEntity);

                await _dbContext.SaveChangesAsync();

                return theaterEntity;
            }
            return null;
        }
    }
}
