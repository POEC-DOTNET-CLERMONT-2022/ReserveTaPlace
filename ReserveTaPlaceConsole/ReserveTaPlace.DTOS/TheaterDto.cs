using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [JsonObject("theater")]
    public class TheaterDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        public AddressDto Address { get; set; }

        [JsonProperty(PropertyName = "rooms")]
        public IList<RoomDto> Rooms { get; set; }

        [JsonProperty(PropertyName = "users")]
        public IList<UserDto> Users { get; set; }

        [JsonProperty(PropertyName = "medias")]
        public IList<MediaDto> Medias { get; set; }
    }
}
