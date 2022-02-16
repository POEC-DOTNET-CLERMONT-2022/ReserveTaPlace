using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class UserRoleDto
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public RoleDto Role { get; set; }
    }
}
