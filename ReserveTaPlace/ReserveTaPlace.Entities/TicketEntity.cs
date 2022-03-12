using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Ticket")]
    public class TicketEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? sessionId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ScheduleId { get; set; }


        [ForeignKey(nameof(SeatId))]
        public virtual SeatEntity? Seat { get; set; }

        [ForeignKey(nameof(sessionId))]
        public virtual SessionEntity? Session { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual OrderEntity? Order { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        public virtual ScheduleEntity? Schedule { get; set; }
    }
}
