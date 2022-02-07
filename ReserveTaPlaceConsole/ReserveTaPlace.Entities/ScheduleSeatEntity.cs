using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("ScheduleSeat")]
    public class ScheduleSeatEntity
    {
        public Guid ScheduleId { get; set; }
        public Guid SeatId { get; set; }
        public virtual ScheduleEntity Schedule { get; set; }
        public virtual SeatEntity Seat { get; set; }
    }
}
