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
        private PlanningModel _planning;
        public SessionModel(MovieModel movieModel, List<ScheduleModel> schedules, PlanningModel planningModel )
        {
            _id = Guid.NewGuid();
            _movie = movieModel;
            _planning = planningModel;
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
        public PlanningModel Planning
        {
            get { return _planning; }
            set { _planning = value; }
        }
        public IList<ScheduleModel> Schedules
        {
            get { return _schedules; }
            set { _schedules = value; }
        }

    }
}
