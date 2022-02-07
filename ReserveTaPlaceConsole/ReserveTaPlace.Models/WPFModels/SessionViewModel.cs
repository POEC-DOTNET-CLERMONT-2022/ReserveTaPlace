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
        private DateTime _sessionDate;
        private RoomModel _roomModel;
        private MovieModel _selectedMovie;
        private TheaterModel _selectedTheatre;
        private ObservableCollection<ScheduleModel> _schedules;
        public DateTime SessionDate
        {
            get { return _sessionDate; }
            set { _sessionDate = value; }
        }

        public RoomModel RoomModel
        {
            get { return _roomModel; }
            set { _roomModel = value; OnNotifyPropertyChanged();}
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
