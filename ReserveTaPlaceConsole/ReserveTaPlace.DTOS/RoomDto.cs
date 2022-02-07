using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class RoomDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }


        [JsonProperty(PropertyName = "Format")]
        public FormatDto Format { get; set; }

        [JsonProperty(PropertyName = "Seats")]
        public IList<SeatDto> Seats { get; set; }

        [JsonProperty(PropertyName = "Sessions")]
        public IList<SessionDto> Sessions { get; set; }


    }
}
