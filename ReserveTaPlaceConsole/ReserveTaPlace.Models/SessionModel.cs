using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class SessionModel
    {
        private Guid _id;
        private MovieModel _movie;
        private IList<ScheduleModel> _schedules;
        private CalendarModel _calendar;
        public SessionModel(MovieModel movieModel, List<ScheduleModel> schedules, CalendarModel calendar )
        {
            _id = Guid.NewGuid();
            _movie = movieModel;
            _calendar = calendar;
            _schedules = schedules;
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public MovieModel Movie
        {
            get { return _movie; }
            set { _movie = value; }
        }
        public CalendarModel Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }
        public IList<ScheduleModel> Schedules
        {
            get { return _schedules; }
            set { _schedules = value; }
        }

    }
}
