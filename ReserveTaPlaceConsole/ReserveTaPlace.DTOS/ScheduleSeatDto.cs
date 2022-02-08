using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class ScheduleSeatDto
    {
        public Guid SeatId { get; set; }
        public Guid ScheduleId { get; set; }
        public ScheduleDto Schedule { get; set; }
        public SeatDto Seat { get; set; }

    }
}
