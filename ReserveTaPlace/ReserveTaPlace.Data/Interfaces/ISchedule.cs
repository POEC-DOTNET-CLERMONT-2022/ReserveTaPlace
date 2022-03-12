using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Interfaces
{
    public interface ISchedule
    {
        Task<ScheduleEntity> AddSchedule(ScheduleEntity scheduleEntity);
    }
}
