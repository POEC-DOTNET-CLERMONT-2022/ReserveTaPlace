using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Guid RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty("Sessions")]
        public virtual RoomEntity Room { get; set; }

        [InverseProperty(nameof(SessionHourEntity.Session))]
        public virtual ICollection<SessionHourEntity> SessionHours { get; set; }

    }
}
