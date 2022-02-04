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
        private IList<RoomModel> _rooms;

        public SeatModel(string row, string number, List<RoomModel> rooms)
        {
            _id = Guid.NewGuid();
            _row = row;
            _number = number;
            _rooms = rooms;
        }

        public Guid Id { get => _id; }
        public string Row { get { return _row; } set { _row = value; } }
        public string Number { get { return _number; } set { _number = value; } }
        public IList<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }
    }
}
