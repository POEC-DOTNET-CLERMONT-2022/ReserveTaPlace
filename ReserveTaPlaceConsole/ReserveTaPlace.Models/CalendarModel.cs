using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.Models
{
    public class CalendarModel
    {
        private Guid _id;
        private DateTime _date;
        public CalendarModel(DateTime date)
        {
            _id = Guid.NewGuid();
            _date = date;

        }
        [JsonProperty(PropertyName = "Id")]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [JsonProperty(PropertyName = "Date")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}