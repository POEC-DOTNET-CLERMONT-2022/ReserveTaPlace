using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("SessionHour")]
    public class SessionHourEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("SessionHours")]
        public virtual SessionEntity Session { get; set; }
    }
}
