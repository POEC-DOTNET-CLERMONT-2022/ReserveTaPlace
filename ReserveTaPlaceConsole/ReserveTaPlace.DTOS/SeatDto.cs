using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("seat")]
    public class SeatDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "row")]
        public string Row { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }


    }
}
