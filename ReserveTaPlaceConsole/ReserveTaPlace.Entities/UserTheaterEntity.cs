using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("UserTheater")]
    public class UserTheaterEntity
    {
        public Guid UserId { get; set; }
        public Guid TheaterId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual TheaterEntity Theater { get; set; }
    }
}
