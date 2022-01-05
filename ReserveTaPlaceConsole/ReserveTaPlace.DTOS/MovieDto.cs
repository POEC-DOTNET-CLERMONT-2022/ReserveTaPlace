using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    [DataContract]
    public class MovieDto
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ImdbID { get; set; }
    }
}
