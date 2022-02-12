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
        public async Task<bool> AddRoomSession(Guid roomId, SessionEntity session)
        {
            RoomEntity room = await _dbContext.Set<RoomEntity>().FirstOrDefaultAsync(r=>r.Id==roomId);
            room.Sessions.Add(session);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<RoomEntity>> GetAll()
        {
            var result = await _dbContext.Set<RoomEntity>().Include(r=>r.Format).Include(r=>r.Sessions).ToListAsync();
            return result;
        }
    }
}
