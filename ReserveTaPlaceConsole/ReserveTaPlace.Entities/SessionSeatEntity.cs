using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("SessionSeat")]
    public class SessionSeatEntity
    {
        public Guid SessionId { get; set; }
        public Guid SeatId { get; set; }
        public virtual SessionEntity Session { get; set; }
        public virtual SeatEntity Seat { get; set; }
    }
}
