using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Schedule")]
    public class ScheduleEntity
    {
        public ScheduleEntity()
        {
            Seats = new HashSet<SeatEntity>();
            Sessions = new HashSet<SessionEntity>();
            Tickets = new HashSet<TicketEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime HourStart { get; set; }
        public DateTime HourEnd { get; set; }

        public ICollection<SessionEntity> Sessions { get; set; }
        public virtual ICollection<SeatEntity> Seats { get; set; }
        public virtual ICollection<TicketEntity> Tickets { get; set; }

    }
}
