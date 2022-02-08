using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("format")]
    public class FormatDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
