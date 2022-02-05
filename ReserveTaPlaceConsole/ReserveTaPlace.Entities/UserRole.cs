﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
