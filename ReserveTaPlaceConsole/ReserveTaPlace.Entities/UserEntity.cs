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
        public UserEntity()
        {
            Orders = new HashSet<OrderEntity>();
            Discounts = new HashSet<DiscountEntity>();
            UserTheaters = new HashSet<UserTheaterEntity>();
            UserRoles = new HashSet<UserRoleEntity>();
        }

        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [Column("FirstName", TypeName = "nvarchar(70)", Order = 2)]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "nvarchar(70)", Order = 3)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column("Email", TypeName = "nvarchar(255)", Order = 4)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Column("Password", TypeName = "nvarchar(50)", Order = 5)]
        public string Password { get; set; }
        public virtual ICollection<OrderEntity>? Orders { get; set; }
        public virtual ICollection<DiscountEntity> Discounts { get; set; }
        public virtual ICollection<UserTheaterEntity> UserTheaters { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }



    }
}
