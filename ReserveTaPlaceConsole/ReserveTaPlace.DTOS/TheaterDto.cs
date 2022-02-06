﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class TheaterDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Rooms")]
        public IList<RoomDto> Rooms { get; set; }

        [JsonProperty(PropertyName = "Users")]
        public IList<UserDto> Users { get; set; }


    }
}
