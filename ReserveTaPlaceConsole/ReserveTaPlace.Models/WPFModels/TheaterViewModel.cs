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
        private ObservableCollection<List<SeatModel>> _seatList;
        private ObservableCollection<List<RoomModel>> _roomList;
        private ObservableCollection<List<UserModel>> _userList;
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

        public ObservableCollection<List<SeatModel>> SeatList
        {
            get { return _seatList; }
            set
            {
                if (_seatList != value)
                {
                    _seatList = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<List<RoomModel>> RoomList
        {
            get { return _roomList; }
            set 
            { 
                if(_roomList != value)
                {
                    _roomList = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<List<UserModel>> UserList
        {
            get { return _userList; }
            set 
            {
                if(_userList != value)
                {
                    _userList = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public TheaterModel TheaterToCreate
        {
            get { return _theaterToCreate; }
            set { _theaterToCreate = value; }
        }

    }
}
