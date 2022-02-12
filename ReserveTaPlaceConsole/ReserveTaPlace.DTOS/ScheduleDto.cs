using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("schedule")]
    public class ScheduleDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "HourStart")]
        public DateTime HourStart { get; set; }

        [JsonProperty(PropertyName = "HourEnd")]
        public DateTime HourEnd { get; set; }
    }
}