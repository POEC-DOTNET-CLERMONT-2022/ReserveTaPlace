using System;

namespace ReserveTaPlace.Models
{
    public class ScheduleModel
    {
        private Guid _id;
        private Guid _sessionId;
        private DateTime _hourStart;
        private DateTime _hourEnd;
        public ScheduleModel(DateTime hourStart, DateTime hourEnd )
        {
            _id = Guid.NewGuid();
            _hourStart = hourStart;
            _hourEnd = hourEnd;
        }
        public Guid SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime HourStart
        {
            get { return _hourStart; }
            set { _hourStart = value; }
        }
        public DateTime HourEnd
        {
            get { return _hourEnd; }
            set { _hourEnd = value; }
        }
    }
}