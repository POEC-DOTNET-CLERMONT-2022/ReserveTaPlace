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
        public async Task<TheaterEntity> Add(TheaterEntity theaterEntity)
        {
            var adress = theaterEntity.Address;
            var rooms = theaterEntity.Rooms;
            var theater = new TheaterEntity();
            theater.Id = theaterEntity.Id;
            theater.Name = theaterEntity.Name;
            await _dbContext.Set<TheaterEntity>().AddAsync(theater);
            var availableTheater = await _dbContext.Set<TheaterEntity>().FindAsync(theater.Id);
            adress.Theater=theater;
            await _dbContext.Set<AddressEntity>().AddAsync(adress);
            await _dbContext.SaveChangesAsync();
            foreach (var room in rooms)
            {
                var seats = new List<SeatEntity>();

                foreach (var seat in room.Seats)
                {
                    var availableSeat = await _dbContext.Set<SeatEntity>().FirstOrDefaultAsync(s => s.Id == seat.Id);
                    seats.Add(availableSeat);
                }
                room.Seats.Clear();
                room.Theater = theater;
                room.Seats = seats;
                room.Format = await _dbContext.Set<FormatEntity>().FindAsync(room.FormatId);
                await _dbContext.Set<RoomEntity>().AddAsync(room);
                await _dbContext.SaveChangesAsync();

            }

            return theaterEntity;
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
                .Include(t => t.Rooms).ThenInclude(r => r.Seats).ThenInclude(r => r.Schedules)
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
