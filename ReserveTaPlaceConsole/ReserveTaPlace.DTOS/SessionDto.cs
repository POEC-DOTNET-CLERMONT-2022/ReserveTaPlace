using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("session")]
    public class SessionDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("movie")]
        public MovieDto Movie { get; set; }

        [JsonProperty("planning")]
        public PlanningDto Planning { get; set; }

        [JsonProperty("schedules")]
        public IList<ScheduleDto> Schedules { get; set; }
    }
}
