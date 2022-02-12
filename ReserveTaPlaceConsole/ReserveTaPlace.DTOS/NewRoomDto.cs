using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class NewRoomDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "TheaterId")]
        public Guid TheaterId { get; set; }
        [JsonProperty(PropertyName = "FormatId")]
        public Guid FormatId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }


        //[JsonProperty(PropertyName = "Format")]
        //public FormatDto Format { get; set; }
        //[JsonProperty(PropertyName = "Theatre")]
        //public TheaterDto Theater { get; set; }

    }
}
