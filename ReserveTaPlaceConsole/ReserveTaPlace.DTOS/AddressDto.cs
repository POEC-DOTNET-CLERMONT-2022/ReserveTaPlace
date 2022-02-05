using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.DTOS
{
    public class AddressDto
    {
        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "Address1")]
        public string Address1 { get; set; }
        [JsonProperty(PropertyName = "Address2")]
        public string Address2 { get; set; }
        [JsonProperty(PropertyName = "Street")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "PostalCode")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "Number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "County")]
        public string County { get; set; }

    }
}
