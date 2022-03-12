using System;

namespace ReserveTaPlace.Models
{
    public class PlanningModel
    {
        private Guid _id;
        private DateTime _startDate;
        private DateTime _endDate;
        public PlanningModel(DateTime startDate,DateTime endDate)
        {
            _id = Guid.NewGuid();
            _startDate = startDate;
            _endDate = endDate;
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

    }
}