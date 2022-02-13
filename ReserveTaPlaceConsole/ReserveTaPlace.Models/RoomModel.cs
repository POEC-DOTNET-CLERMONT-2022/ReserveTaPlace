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
        private List<SeatModel> _seats;
        private List<SessionModel> _sessions;
        private Guid _theatreId;

        public RoomModel()
        {

        }
        [JsonConstructor]
        public RoomModel(Guid id, Guid? theatreId, string name, string number, FormatModel format, List<SeatModel>? seats, List<SessionModel>? sessions)
        {
            _id = id;
            _name = name;
            _number = number;
            _format = format;
            _seats = seats ?? new List<SeatModel>();
            _sessions = sessions ?? new List<SessionModel>();
            _theatreId =theatreId ?? new Guid();
        }

        public Guid TheaterId
        {
            get { return _theatreId; }
            set { _theatreId = value; }
        }
        public Guid Id { get => _id; set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Number { get { return _number; } set { _number = value; } }
        public FormatModel Format { get { return _format; } set { _format = value; } }
        public List<SeatModel> Seats { get { return _seats; } set { _seats = value; } }
        public List<SessionModel> Sessions { get { return _sessions; } set { _sessions = value; } }
        public int TotalSeats { get { return _seats.Count; } set { TotalSeats = value; } }


    }
}
