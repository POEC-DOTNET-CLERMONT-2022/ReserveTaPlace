using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Discount")]
    public class DiscountEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime EndValidityDate { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual DiscountType DiscountType { get; set; }


    }
}
