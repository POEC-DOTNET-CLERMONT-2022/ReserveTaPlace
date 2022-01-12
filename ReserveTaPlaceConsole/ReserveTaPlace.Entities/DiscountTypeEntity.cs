using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveTaPlace.Entities
{
    [Table("DiscountType")]
    public class DiscountTypeEntity
    {
        public DiscountTypeEntity()
        {
            Discounts = new HashSet<DiscountEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public short Rate { get; set; }
        public float Amount { get; set; }

        [InverseProperty(nameof(DiscountEntity.DiscountTypeId))]
        public virtual ICollection<DiscountEntity> Discounts { get; set; }
    }
}
