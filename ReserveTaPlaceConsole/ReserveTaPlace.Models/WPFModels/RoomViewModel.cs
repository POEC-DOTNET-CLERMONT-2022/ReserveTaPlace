using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models.WPFModels
{
    public class RoomViewModel : ObservableObject
    {
        private ObservableCollection<RoomModel> _rooms;
        private ObservableCollection<List<SeatModel>> _seats;
        private ObservableCollection<FormatModel> _formats;
        private RoomModel _roomToCreate;

        public ObservableCollection<RoomModel> Rooms
        {
            get { return _rooms; }
            set
            {
                if (_rooms != value)
                {
                    _rooms = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<List<SeatModel>> Seats
        {
            get { return _seats; }
            set
            {
                if (_seats != value)
                {
                    _seats = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public RoomModel RoomToCreate
        {
            get { return _roomToCreate; }
            set { _roomToCreate = value; }
        }
        public ObservableCollection<FormatModel> Formats
        {
            get { return _formats; }
            set
            {
                if (_formats != value)
                {
                    _formats = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
