using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class RoomSeatModel
    {
        private Guid _roomId;
        private Guid _seatId;
        private RoomModel _room;
        private SeatModel _seat;

        public RoomSeatModel(Guid rommId, Guid seatId, RoomModel room, SeatModel seat)
        {
            _roomId = rommId;
            _seatId = seatId;
            _room = room;
            _seat = seat;
        }

        public Guid RoomId { get { return _roomId; } set { _roomId = value; } }
        public Guid SeatId { get { return _seatId; } set { _seatId = value; } }
        public RoomModel Room { get { return _room; } set { _room = value; } }
        public SeatModel Seat { get { return _seat; } set { _seat = value; } }
    }
}
