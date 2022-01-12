using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("UserRoles")]
        public UserRolesEntity UserRoles { get; set; }

        [InverseProperty(nameof(OrderEntity.UserId))]
        public virtual IEnumerable<OrderEntity> Orders { get; set; }

        public virtual IEnumerable<DiscountEntity> Discounts { get; set; }


    }
}
