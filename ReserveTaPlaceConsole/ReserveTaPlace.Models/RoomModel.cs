using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class RoomModel
    {
        private Guid _id;
        private string _name;
        private string _number;
        private FormatModel _format;
        private IList<SeatModel> _seats;
        private IList<SessionModel> _sessions;

        [JsonConstructor]
        public RoomModel(Guid id, string name, string number, FormatModel format, List<SeatModel> seats, List<SessionModel> sessions)
        {
            _id = id;
            _name = name;
            _number = number;
            _format = format;
            _seats = seats;
            _sessions = sessions;
        }

        public Guid Id { get => _id; }
        public string Name { get { return _name; } set { _name = value; } }
        public string Number { get { return _number; } set { _number = value; } }
        public FormatModel Format { get { return _format; } set { _format = value; } }
        public IList<SeatModel> Seats { get { return _seats; } set { _seats = value; } }
        public IList<SessionModel> Sessions { get { return _sessions; } set { _sessions = value; } }
        public int TotalSeats { get { return _seats.Count; } set { TotalSeats = value; } }


    }
}
