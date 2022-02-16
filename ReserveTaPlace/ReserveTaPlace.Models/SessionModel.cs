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
        private List<ScheduleModel> _schedules;
        private CalendarModel _calendar;
        private RoomModel _room;
        private Guid _roomId;
        private Guid _calendarId;
        private Guid _movieId;

        public SessionModel(MovieModel movie, CalendarModel calendar, RoomModel room )
        {
            _id = Guid.NewGuid();
            _movie = movie;
            _calendar = calendar;
            _schedules = new List<ScheduleModel>();
            _room = room;
            _roomId = room.Id;
            _calendarId = calendar.Id;
            _movieId = movie.Id;
        }
        public Guid MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
        }
        public Guid CalendarId
        {
            get { return _calendarId; }
            set { _calendarId = value; }
        }
        public Guid RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public RoomModel Room
        {
            get { return _room; }
            set { _room = value; }
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
        public List<ScheduleModel> Schedules
        {
            get { return _schedules; }
            set { _schedules = value; }
        }

    }
}
