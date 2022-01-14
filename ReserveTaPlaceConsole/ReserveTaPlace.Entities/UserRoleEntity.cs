using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("UserRole")]
    public class UserRoleEntity
    {
        [Key]
        public Guid RoleId { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Roles")]
        public virtual UserEntity User { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Users")]
        public virtual RoleEntity Role { get; set; }
    }
}
