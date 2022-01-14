using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("MovieOrigin")]
    public class MovieOriginEntity
    {
        [Key]
        public Guid MovieId { get; set; }
        [Key]
        public Guid OriginId { get; set; }

        [ForeignKey(nameof(OriginId))]
        [InverseProperty("Origins")]
        public virtual MovieEntity Movie { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Movies")]
        public virtual OriginEntity Origin { get; set; }
    }
}
