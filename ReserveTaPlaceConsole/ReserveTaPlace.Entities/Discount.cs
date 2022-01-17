using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime EndValidityDate { get; set; }
        public virtual User User { get; set; }
        public virtual DiscountType DiscountType { get; set; }


    }
}
