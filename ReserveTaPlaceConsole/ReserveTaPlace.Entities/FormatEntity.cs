using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Format")]
    public class FormatEntity
    {
        public FormatEntity()
        {
            Rooms = new HashSet<RoomEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(RoomEntity.Format))]
        public virtual ICollection<RoomEntity> Rooms { get; set; }
    }
}
