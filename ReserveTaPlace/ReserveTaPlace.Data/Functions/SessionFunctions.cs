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
    public class SessionFunctions : ISessions
    {
        private DbContext _dbContext;
        public SessionFunctions(DbContext DbContext)
        {
            _dbContext= DbContext;
        }
        public async Task<bool> AddSessions(List<SessionEntity> sessionEntities)
        {
            var room = await _dbContext.Set<RoomEntity>().FirstOrDefaultAsync(r=>r.Id == sessionEntities[0].RoomId);
            await _dbContext.Set<SessionEntity>().AddRangeAsync(sessionEntities);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<SessionEntity>> GetSessions()
        {
            var result = await _dbContext.Set<SessionEntity>()
                //.Include(s=>s.Schedules)
                .ToListAsync();
            return result;

        }
    }
}
