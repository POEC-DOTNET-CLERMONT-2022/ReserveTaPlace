using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    [Table("UserRole")]
    public class UserRoleEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
