using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("NewTheater")]
    public class NewTheaterDto
    {

        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public AddressDto Address { get; set; }

        [JsonProperty(PropertyName = "Medias")]
        public IList<MediaDto> Medias { get; set; }

        [JsonProperty(PropertyName = "Rooms")]
        public IList<NewRoomDto> Rooms { get; set; }

    }
}
