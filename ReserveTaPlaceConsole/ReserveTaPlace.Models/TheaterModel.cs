using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class TheaterModel
    {
        private Guid _id;
        private string _name;
        private List<MediaModel> _medias;
        private List<RoomModel> _rooms;
        private List<UserModel> _users;


        [JsonConstructor]
        public TheaterModel(Guid id, string name, List<MediaModel> medias, List<RoomModel> rooms, List<UserModel> users)
        {
            _id = id;
            _name = name;
            _medias = medias;
            _rooms = rooms;
            _users = users;
        }

        public Guid Id { get => _id; set { _id = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public List<MediaModel> Medias { get { return _medias; } set { _medias = value; } }

        public List<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }

        public List<UserModel> Users { get { return _users; } set { _users = value; } }
    }
}
