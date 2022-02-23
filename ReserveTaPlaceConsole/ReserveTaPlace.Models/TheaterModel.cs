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
        private AddressModel _address;
        private IList<MediaModel> _medias;
        private IList<RoomModel> _rooms;
        private IList<UserModel> _users;

        [JsonConstructor]
        public TheaterModel(Guid id, string name, AddressModel address, List<MediaModel> medias, List<RoomModel> rooms, List<UserModel> users)
        {
            _id = id;
            _name = name;
            _address = address;
            _medias = medias;
            _rooms = rooms;
            _users = users;
        }

        public TheaterModel(string name, AddressModel address)
        {
            _id = Guid.NewGuid();
            _name = name;
            _address = address;
            _medias = new List<MediaModel>();
            _rooms = new List<RoomModel>();
        }

        public Guid Id { get => _id; }

        public string Name { get { return _name; } set { _name = value; } }

        [JsonPropertyName("Address")]
        public AddressModel Address { get { return _address; } set { _address = value; } }

        [JsonPropertyName("Medias")]
        public IList<MediaModel> Medias { get { return _medias; } set { _medias = value; } }

        public IList<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }

        public IList<UserModel> Users { get { return _users; } set { _users = value; } }
    }
}
