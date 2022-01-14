using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Theater")]
    public class TheaterEntity
    {
        public TheaterEntity()
        {
            Users = new HashSet<UserTheaterEntity>();
            Rooms = new HashSet<RoomEntity>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(UserTheaterEntity.Theater))]
        public virtual ICollection<UserTheaterEntity> Users { get; set; }

        [InverseProperty(nameof(RoomEntity.Theater))]
        public virtual ICollection<RoomEntity> Rooms { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual AddressEntity Address { get; set; }


    }
}
