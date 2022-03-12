using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class SeatModel
    {
        private Guid _id;
        private string _row;
        private string _number;

        [JsonConstructor]
        public SeatModel(Guid id, string row, string number)
        {
            _id = id;
            _row = row;
            _number = number;
        }

        public SeatModel(string row, string number)
        {
            _id = Guid.NewGuid();
            _row = row;
            _number = number;
        }

        public Guid Id { get => _id; }
        public string Row { get { return _row; } set { _row = value; } }
        public string Number { get { return _number; } set { _number = value; } }
    }
}
