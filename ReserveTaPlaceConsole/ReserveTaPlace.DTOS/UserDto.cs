using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("user")]
    public class UserDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string Firstname { get; set; }

        [JsonProperty("lastName")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        //[JsonProperty("orders")]
        //public IList<OrderDto> Orders { get; set; }
        //[JsonProperty("discounts")]
        //public IList<DiscountDto> Discounts { get; set; }

        [JsonProperty("roles")]
        public IList<RoleDto> Roles { get; set; }
    }
}
