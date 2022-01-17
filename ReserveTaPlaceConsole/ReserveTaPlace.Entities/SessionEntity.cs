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
        public int Id { get; set; }
        public int MovieRoomId { get; set; }

        [ForeignKey(nameof(MovieRoomId))]
        [InverseProperty("Sessions")]
        public virtual MovieRoomEntity MovieRoom { get; set; }

        public virtual ICollection<SessionHourEntity> SessionHours { get; set; }

    }
}
