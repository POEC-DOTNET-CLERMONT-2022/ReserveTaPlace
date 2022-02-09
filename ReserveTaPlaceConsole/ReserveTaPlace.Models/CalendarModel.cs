using System;

namespace ReserveTaPlace.Models
{
    public class CalendarModel
    {
        private Guid _id;
        private DateTime _sessionDate;
        public CalendarModel(DateTime sessionDate)
        {
            _id = Guid.NewGuid();
            _sessionDate = sessionDate;

        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime SessionDate
        {
            get { return _sessionDate; }
            set { _sessionDate = value; }
        }

    }
}