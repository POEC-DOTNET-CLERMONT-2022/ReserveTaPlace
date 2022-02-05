using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("RoomSeat")]
    public class RoomSeatEntity
    {
        public Guid RoomId { get; set; }
        public Guid SeatId { get; set; }
        public virtual RoomEntity Room { get; set; }
        public virtual SeatEntity Seat { get; set; }
    }
}
