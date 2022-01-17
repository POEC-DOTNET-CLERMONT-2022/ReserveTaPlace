using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Session")]
    public class SessionEntity
    {
        public SessionEntity()
        {
            SessionHours = new HashSet<SessionHourEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public virtual RoomEntity Room { get; set; }
        public virtual ICollection<SessionHourEntity> SessionHours { get; set; }

    }
}
