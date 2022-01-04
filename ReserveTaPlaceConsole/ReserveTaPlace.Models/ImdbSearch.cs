﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class ImdbSearch
    {
        [JsonProperty(PropertyName = "Search")]
        public List<ImdbMovie> ImdbMovies { get; set; }
    }
}