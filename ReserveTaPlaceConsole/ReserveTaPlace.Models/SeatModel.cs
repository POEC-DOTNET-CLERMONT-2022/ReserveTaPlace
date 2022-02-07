using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class SeatModel
    {
        private Guid _id;
        private string _row;
        private string _number;
        private IList<RoomSeatModel> _seatRooms;
      
        public SeatModel(string row, string number, List<RoomSeatModel> seatRooms)
        {
            _id = Guid.NewGuid();
            _row = row;
            _number = number;
            _seatRooms = seatRooms;
        }

        public Guid Id { get => _id; }
        public string Row { get { return _row; } set { _row = value; } }
        public string Number { get { return _number; } set { _number = value; } }
        public IList<RoomSeatModel> SeatRooms { get { return _seatRooms; } set { _seatRooms = value; } }
    }
}
