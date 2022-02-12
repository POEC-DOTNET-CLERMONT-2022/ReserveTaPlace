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
        }
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Guid? RoomId { get; set; }
        public Guid? CalendarId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public virtual MovieEntity? Movie { get; set; }

        [ForeignKey(nameof(CalendarId))]
        public virtual CalendarEntity? Calendar { get; set; }
        //[InverseProperty("Sessions")]
        //public RoomEntity? Room { get; set; }
        public virtual ICollection<ScheduleEntity> Schedules { get; set; }

    }
}
