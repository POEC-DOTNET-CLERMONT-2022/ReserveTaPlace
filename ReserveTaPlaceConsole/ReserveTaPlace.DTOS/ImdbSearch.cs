using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "Search")]
        public List<ImdbMovie> ImdbMovies { get; set; } = new List<ImdbMovie>();
    }
}
