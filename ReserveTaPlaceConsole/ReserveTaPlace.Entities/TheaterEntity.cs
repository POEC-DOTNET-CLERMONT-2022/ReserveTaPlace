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
            Users = new HashSet<UserEntity>();
            MovieRooms = new HashSet<MovieRoomEntity>();
        }

        [Key]
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(UserTheaterEntity.TheaterId))]
        public virtual ICollection<UserEntity> Users { get; set; }

        [InverseProperty(nameof(MovieRoomEntity.TheatreId))]
        public virtual ICollection<MovieRoomEntity> MovieRooms { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual AddressEntity Address { get; set; }


    }
}
