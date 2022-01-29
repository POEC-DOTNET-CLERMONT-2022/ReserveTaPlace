using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("Discount")]
    public class DiscountEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? DicountTypeId { get; set; }
        [Column("Number", TypeName = "nvarchar(35)")]
        public string Number { get; set; }
        public short? Rate { get; set; }
        public float? Amount { get; set; }
        public DateTime EndValidityDate { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity? User { get; set; }
        [ForeignKey(nameof(DicountTypeId))]
        public virtual DiscountType? DiscountType { get; set; }


    }
}
