using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("UserTheater")]
    public class UserTheaterEntity
    {
        [Key]
        public Guid UserId { get; set; }

        [Key]
        public Guid TheaterId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Users")]
        public virtual TheaterEntity Theater { get; set; }

        [ForeignKey(nameof(TheaterId))]
        [InverseProperty("Theaters")]
        public virtual UserEntity User { get; set; }

    }
}
