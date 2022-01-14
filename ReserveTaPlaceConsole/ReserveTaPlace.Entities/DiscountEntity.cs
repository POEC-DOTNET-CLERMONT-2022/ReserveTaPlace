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
    public class DiscountEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DiscountTypeId { get; set; }
        public string Number { get; set; }
        public DateTime EndValidityDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Discounts")]
        public virtual UserEntity User { get; set; }

        [ForeignKey(nameof(DiscountTypeId))]
        [InverseProperty("Discounts")]
        public virtual DiscountTypeEntity DiscountType { get; set; }


    }
}
