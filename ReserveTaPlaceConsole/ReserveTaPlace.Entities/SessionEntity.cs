using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Session")]
    public class SessionEntity
    {
        public SessionEntity()
        {
            Schedules = new HashSet<ScheduleEntity>();
            SessionSeats = new HashSet<SessionSeatEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid? RoomId { get; set; }
        public virtual MovieEntity? Movie { get; set; }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty("Sessions")]
        public RoomEntity? Room { get; set; }
        public virtual ICollection<ScheduleEntity>? Schedules { get; set; }
        public virtual DateEntity? Date { get; set; }
        public virtual ICollection<SessionSeatEntity> SessionSeats { get; set; }

    }
}
