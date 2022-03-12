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
    internal class ScheduleFunctions : ISchedule
    {
        private DbContext _dbContext;
        public ScheduleFunctions(DbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public async Task<ScheduleEntity> AddSchedule(ScheduleEntity scheduleEntity)
        {
            throw new NotImplementedException();
        }
    }
}
