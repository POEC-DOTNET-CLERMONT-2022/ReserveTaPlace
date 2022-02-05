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
        private IList<RoomModel> _rooms;
        private IList<UserModel> _users;
      
        public TheaterModel(string name, List<RoomModel> rooms, List<UserModel> users)
        {
            _id = Guid.NewGuid();
            _name = name;
            _rooms = rooms;
            _users = users;
        }

        public Guid Id { get => _id; }
        public string Name { get { return _name; } set { _name = value; } }
        public IList<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }
        public IList<UserModel> Users { get { return _users; } set { _users = value; } }
    }
}
