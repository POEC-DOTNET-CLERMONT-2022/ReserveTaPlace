using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class UserDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        //[JsonProperty("orders")]
        //public IList<OrderDto> Orders { get; set; }
        //[JsonProperty("discounts")]
        //public IList<DiscountDto> Discounts { get; set; }

        [JsonProperty(PropertyName = "Roles")]
        public IList<RoleDto> Roles { get; set; }


    }
}
