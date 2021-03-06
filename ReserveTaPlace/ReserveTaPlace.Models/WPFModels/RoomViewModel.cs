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
        private ObservableCollection<RoomModel> _roomsToCreate;
        private ObservableCollection<SeatModel> _seats;
        private ObservableCollection<FormatModel> _formats;
        private RoomModel _roomToCreate;
        public RowModel Row = new RowModel();
        private ObservableCollection<RowModel> _rowModels;

        public ObservableCollection<RowModel> RowModels
        {
            get { return _rowModels; }
            set { _rowModels = value; }
        }


        public ObservableCollection<RoomModel> RoomsToCreate
        {
            get { return _roomsToCreate; }
            set
            {
                if (_roomsToCreate != value)
                {
                    _roomsToCreate = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<SeatModel> Seats
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
