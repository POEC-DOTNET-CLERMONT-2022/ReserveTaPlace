using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class ImdbMovie
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title;
        [JsonProperty(PropertyName = "Year")]
        public string Year;
        [JsonProperty(PropertyName = "ImdbID")]
        public string ImdbID;
        [JsonProperty(PropertyName = "Poster")]
        public string Poster;
        [JsonProperty(PropertyName = "Country")]
        public string Country;
    }
}
