using System;

namespace ReserveTaPlace.DTOS
{
    public class ScheduleDto
    {
        public Guid _id { get; set; }
        public DateTime _hourStart { get; set; }
        public DateTime _hourEnd { get; set; }
    }
}