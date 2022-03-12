using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class NewSessionDto
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid CalendarId { get; set; }
        public Guid MovieId { get; set; }
        public List<ScheduleDto> Schedules { get; set; }

    }
}
