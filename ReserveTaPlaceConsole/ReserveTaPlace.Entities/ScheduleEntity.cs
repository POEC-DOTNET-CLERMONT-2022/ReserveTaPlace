using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Schedule")]
    public class ScheduleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? SessionId { get; set; }
        public DateTime HourStart { get; set; }
        public DateTime HourEnd { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("Schedules")]
        public SessionEntity? Session { get; set; }
    }
}
