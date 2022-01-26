using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Ticket")]
    public class TicketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? RoomId { get; set; }

        //public Guid SessionId { get; set; }

        [ForeignKey(nameof(SeatId))]
        public virtual SeatEntity? Seat { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual RoomEntity? Room { get; set; }


    }
}
