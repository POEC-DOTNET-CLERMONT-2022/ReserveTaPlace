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
    public class CalendarFunctions : ICalendar
    {
        private DbContext _dbContext;
        private CalendarEntity _calendar;
        public CalendarFunctions(DbContext DbContext)
        {
            _calendar = new CalendarEntity();
            _dbContext = DbContext;
        }
        public async Task<CalendarEntity> GetCalendarByDate(string sessionDate)
        {
            var dateTime = DateTime.Parse(sessionDate);
            _calendar = await _dbContext.Set<CalendarEntity>().FirstOrDefaultAsync(c => c.Date == dateTime);
            return _calendar;
        }
    }
}
