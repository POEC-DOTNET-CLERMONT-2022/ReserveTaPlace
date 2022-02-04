using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Schedule")]
    public class ScheduleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid? SessionId { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("Schedules")]
        public SessionEntity? Session { get; set; }
    }
}
