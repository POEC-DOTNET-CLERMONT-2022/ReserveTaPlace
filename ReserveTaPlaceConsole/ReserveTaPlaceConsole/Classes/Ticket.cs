using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole.Classes
{
    internal class Ticket
    {
        private Guid _id;
        private DateTime _date;
        private string _movieRoomNumber;
        private string _theatreName;
        private string _movieName;
        private decimal _price;

        public Ticket(DateTime date, string movieRoomNumber, string theatreName, string movieName, decimal price)
        {
            _id = Guid.NewGuid();
            _date = date;
            _movieRoomNumber = movieRoomNumber;
            _theatreName = theatreName;
            _movieName = movieName;
            _price = price;
        }

        public Guid Id { get { return _id; } }
        public DateTime Date { get { return _date;} }
        public string MovieRoomNumber { get { return _movieRoomNumber; } }
        public string TheatreName { get { return _theatreName; } }
        public string MovieName { get { return _movieName; } }
        public decimal Price { get { return _price;} }
    }
}
