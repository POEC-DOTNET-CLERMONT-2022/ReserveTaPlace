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
        public virtual MovieEntity? Movie { get; set; }
        public virtual ICollection<ScheduleEntity>? Schedules { get; set; }


    }
}
