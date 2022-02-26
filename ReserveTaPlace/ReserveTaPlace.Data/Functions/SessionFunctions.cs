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
        public async Task<SessionEntity> AddSession(SessionEntity session)
        {
            CalendarEntity calendar = await _dbContext.Set<CalendarEntity>().FindAsync(session.CalendarId);
            session.Calendar = calendar;
            await _dbContext.Set<SessionEntity>().AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return session;
        }
        public async Task<bool> AddSessions(List<SessionEntity> sessionEntities)
        {
            foreach (var session in sessionEntities)
            {
                await AddSession(session);
            }
            //await _dbContext.Set<SessionEntity>().AddRangeAsync(sessionEntities);
            //var result = await _dbContext.SaveChangesAsync();
            return true;
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
