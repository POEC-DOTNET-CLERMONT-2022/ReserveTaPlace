using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [NotMapped]
    public abstract class GenericEntity
    {
        public Guid Id { get; set; }

    }
}
