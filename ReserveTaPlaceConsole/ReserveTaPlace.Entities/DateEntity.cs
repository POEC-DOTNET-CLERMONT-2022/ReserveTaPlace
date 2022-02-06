using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Date")]
    public class DateEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("Date")]
        public virtual SessionEntity? Session { get; set; }


    }
}
