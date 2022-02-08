using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("schedule")]
    public class ScheduleDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("hourStart")]
        public DateTime HourStart { get; set; }

        [JsonProperty("hourEnd")]
        public DateTime HourEnd { get; set; }
    }
}