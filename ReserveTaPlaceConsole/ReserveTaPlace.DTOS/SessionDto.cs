using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("session")]
    public class SessionDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "Movie")]
        public MovieDto Movie { get; set; }

        [JsonProperty(PropertyName = "Calendar")]
        public CalendarDto Calendar { get; set; }

        [JsonProperty(PropertyName = "Schedules")]
        public IList<ScheduleDto> Schedules { get; set; }
    }
}
