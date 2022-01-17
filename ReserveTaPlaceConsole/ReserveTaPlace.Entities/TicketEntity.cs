using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Ticket")]
    public class TicketEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public int OrderId { get; set; }
        public int SessionId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Tickets")]
        public virtual UserEntity User { get; set; }

        [ForeignKey(nameof(SeatId))]
        public virtual SeatEntity Seat { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Tickets")]
        public virtual OrderEntity Order { get; set; }

        [ForeignKey(nameof(SessionId))]
        public virtual SessionEntity Session { get; set; }

    }
}
