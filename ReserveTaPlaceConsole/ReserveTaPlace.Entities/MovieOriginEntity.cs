using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("MovieOrigin")]
    public class MovieOriginEntity
    {
        public Guid MovieId { get; set; }
        public Guid OriginId { get; set; }
        public virtual MovieEntity Movie { get; set; }
        public virtual OriginEntity Origin { get; set; }
    }
}
