using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IList<OrderDto> Orders { get; set; }
        public IList<DiscountDto> Discounts { get; set; }
        public IList<RoleDto> Roles { get; set; }
    }
}
