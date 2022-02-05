using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public MovieDto Movie { get; set; }
        public PlanningDto _planning { get; set; }
        public IList<ScheduleDto> _schedules { get; set; }
    }
}
