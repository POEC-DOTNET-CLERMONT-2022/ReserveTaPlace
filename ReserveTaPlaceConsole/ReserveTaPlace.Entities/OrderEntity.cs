using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("User")]
    public class OrderEntity
    {

        [ForeignKey(nameof(UserEntity.Id))]
        [InverseProperty("Orders")]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("UserId")]
        public int OrderId { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }

    }
}
