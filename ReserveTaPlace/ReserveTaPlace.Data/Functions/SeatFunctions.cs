using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class SeatFunctions : ISeat
    {
        private IEnumerable<SeatEntity> _seats;
        private DbContext _dbContext;

        public SeatFunctions(DbContext context)
        {
            _dbContext = context;
            _seats = new List<SeatEntity>();
        }
        public async Task<IEnumerable<SeatEntity>> GetAll()
        {
            _seats = await _dbContext.Set<SeatEntity>().ToListAsync();
            return _seats;
        }

        public async Task<IEnumerable<SeatEntity>> GetSeatsByRowAndNumber(string row, string seats)
        {
            _seats = await _dbContext.Set<SeatEntity>().Where(s=> s.Row.ToLower() == row.ToLower() && Convert.ToInt32(s.Number)<= Convert.ToInt32(seats)).ToListAsync();
            return _seats;
        }
    }
}
