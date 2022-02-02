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
            var entity = await _dbContext.Set<TheaterEntity>().FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Set<TheaterEntity>().Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<IEnumerable<TheaterEntity>> GetAll()
        {
            _theaters = await _dbContext.Set<TheaterEntity>().Include(m => m.Address).ToListAsync();
            return _theaters;
        }

        public async Task<PaginatedList<TheaterEntity>> GetAllPaginated(int pageIndex, int pageSize)
        {
            return await PaginatedList<TheaterEntity>.CreateAsync(_dbContext.Set<TheaterEntity>(), pageIndex, pageSize);
        }

        public async Task<TheaterEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TheaterEntity>().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<TheaterEntity> GetByName(string name)
        {
            return await _dbContext.Set<TheaterEntity>().FirstOrDefaultAsync(m => m.Name.ToLower().StartsWith(name));
        }

        public async Task<TheaterEntity> Update(TheaterEntity theater)
        {
            TheaterEntity result = await GetById(theater.Id);
            if(result != null)
            {
                result.Name = theater.Name;
                result.Address = theater.Address;
                result.Rooms = theater.Rooms;
                result.Users = theater.Users;

                await _dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
