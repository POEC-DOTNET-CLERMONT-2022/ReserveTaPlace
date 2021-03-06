using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("seat")]
    public class SeatDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "Row")]
        public string Row { get; set; }

        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }


    }
}
