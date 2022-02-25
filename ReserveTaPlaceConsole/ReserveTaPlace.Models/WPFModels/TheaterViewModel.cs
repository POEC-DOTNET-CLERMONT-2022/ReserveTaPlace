using ReserveTaPlace.Models.WPFModels.StateManager;
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
        private RoomModel _currentRoom;
        private TheaterModel _theaterToCreate;
        private TheaterPageStateManager _stateManager;
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
        public RoomModel CurrentRoom
        {
            get { return _currentRoom; }
            set
            {
                if (_currentRoom != value)
                {
                    _currentRoom = value;
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
        
        public TheaterModel TheaterToCreate
        {
            get { return _theaterToCreate; }
            set { _theaterToCreate = value; }
        }
        public TheaterPageStateManager StateManager
        {
            get { return _stateManager; }
            set { _stateManager = value; OnNotifyPropertyChanged(); }
        }
    }
}
