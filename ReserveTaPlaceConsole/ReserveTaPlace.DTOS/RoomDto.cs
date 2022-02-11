using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("room")]
    public class RoomDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }


        [JsonProperty(PropertyName = "format")]
        public FormatDto Format { get; set; }

        [JsonProperty(PropertyName = "seats")]
        public IList<SeatDto> Seats { get; set; }

        [JsonProperty(PropertyName = "sessions")]
        public IList<SessionDto> Sessions { get; set; }


    }
}
