using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class TheaterModel
    {
        private Guid _id;
        private string _name;
        private MediaModel _media;
        private IList<RoomModel> _rooms;
        private IList<TheaterUserModel> _theaterUsers;

        public TheaterModel()
        {

        }
      
        public TheaterModel(string name, MediaModel media,List<RoomModel> rooms, List<TheaterUserModel> theaterUsers)
        {
            _id = Guid.NewGuid();
            _name = name;
            _media = media;
            _rooms = rooms;
            _theaterUsers = theaterUsers;
        }

        public Guid Id { get => _id; }
        public string Name { get { return _name; } set { _name = value; } }
        public MediaModel Media { get { return _media; } set { _media = value; } }
        public IList<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }
        public IList<TheaterUserModel> TheaterUsers { get { return _theaterUsers; } set { _theaterUsers = value; } }
    }
}
