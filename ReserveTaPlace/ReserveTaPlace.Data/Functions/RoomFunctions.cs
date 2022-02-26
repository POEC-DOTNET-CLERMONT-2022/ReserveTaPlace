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
    public class RoomFunctions : IRoom
    {
        private DbContext _dbContext;
        public RoomFunctions(DbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<IEnumerable<RoomEntity>> GetAll()
        {
            var result = await _dbContext.Set<RoomEntity>().Include(r=>r.Format).Include(r=>r.Sessions).Include(r => r.Theater).ToListAsync();
            return result;
        }
    }
}
