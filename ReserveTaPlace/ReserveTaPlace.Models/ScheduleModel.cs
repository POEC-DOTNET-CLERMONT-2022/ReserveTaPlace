using System;
using System.Collections.Generic;

namespace ReserveTaPlace.Models
{
    public class ScheduleModel
    {
        private Guid _id;
        private DateTime _hourStart;
        private DateTime _hourEnd;
        public List<SessionModel> Sessions { get; set; }=new List<SessionModel>();
        public ScheduleModel(DateTime hourStart, DateTime hourEnd )
        {
            _id = Guid.NewGuid();
            _hourStart = hourStart;
            _hourEnd = hourEnd;
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