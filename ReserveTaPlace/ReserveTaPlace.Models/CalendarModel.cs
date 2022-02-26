using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.Models
{
    public class CalendarModel
    {
        private Guid _id;
        private DateTime _date;
        public CalendarModel(Guid id,DateTime date)
        {
            _id = id;
            _date = date;

        }
        public CalendarModel(DateTime date)
        {
            _id = Guid.NewGuid();
            _date = date;

        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}