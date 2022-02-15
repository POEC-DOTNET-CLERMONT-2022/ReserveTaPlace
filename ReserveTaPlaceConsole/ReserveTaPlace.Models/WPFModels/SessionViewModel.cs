using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class SessionViewModel : ObservableObject
    {
        private ObservableCollection<CalendarModel> _calendars;
        private RoomModel _room;
        private MovieModel _selectedMovie;
        private TheaterModel _selectedTheatre;
        private ObservableCollection<ScheduleModel> _schedules;
        private CalendarModel _currentCalendar;
        private ScheduleModel _currentSchedule;
        private ObservableCollection<TheaterModel> _theaters;

        public ObservableCollection<TheaterModel> Theaters
        {
            get { return _theaters; }
            set { _theaters = value; OnNotifyPropertyChanged(); }
        }
        public ScheduleModel CurrentSchedule
        {
            get { return _currentSchedule; }
            set { _currentSchedule = value; OnNotifyPropertyChanged(); }
        }

        public CalendarModel CurrentCalendar
        {
            get { return _currentCalendar; }
            set { _currentCalendar = value; OnNotifyPropertyChanged(); }
        }

        public ObservableCollection<CalendarModel> Calendars
        {
            get { return _calendars; }
            set { _calendars = value; OnNotifyPropertyChanged(); }
        }

        public RoomModel Room
        {
            get { return _room; }
            set { _room = value; OnNotifyPropertyChanged();}
        }

        public MovieModel SelectedMovie
        {
            get { return _selectedMovie; }
            set { _selectedMovie = value; OnNotifyPropertyChanged();}
        }

        public TheaterModel SelectedTheatre
        {
            get { return _selectedTheatre; }
            set { _selectedTheatre = value; OnNotifyPropertyChanged();}
        }

        public ObservableCollection<ScheduleModel> Schedules
        {
            get { return _schedules; }
            set { _schedules = value; OnNotifyPropertyChanged();}
        }

    }
}
