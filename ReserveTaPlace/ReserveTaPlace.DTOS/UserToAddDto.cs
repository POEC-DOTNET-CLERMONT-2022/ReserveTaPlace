using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class UserToAddDto
    {
        public Guid RoleId { get; set; }
        public UserDto UserDto { get; set; }
    }
}
