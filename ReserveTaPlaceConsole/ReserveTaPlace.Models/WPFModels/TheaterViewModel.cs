using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class TheaterViewModel : ObservableObject
    {
        private ObservableCollection<TheaterModel> _theaters;
        private TheaterModel _currentTheater;
        public TheaterModel CurrentTheater
        {
            get { return _currentTheater; }
            set 
            { 
                if (_currentTheater != value)
                {
                    _currentTheater = value;
                    OnNotifyPropertyChanged();
                } 
            }
        }
        public ObservableCollection<TheaterModel> Theaters
        {
            get { return _theaters; }
            set 
            { 
                if(_theaters != value)
                {
                    _theaters = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
