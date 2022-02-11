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
        private IList<MediaModel> _medias;
        private IList<RoomModel> _rooms;
        private IList<UserModel> _users;


        [JsonConstructor]
        public TheaterModel(Guid id, string name, List<MediaModel> medias, List<RoomModel> rooms, List<UserModel> users)
        {
            _id = id;
            _name = name;
            _medias = medias;
            _rooms = rooms;
            _users = users;
        }

        [JsonPropertyName("id")]
        public Guid Id { get => _id; }

        [JsonPropertyName("name")]
        public string Name { get { return _name; } set { _name = value; } }

        [JsonPropertyName("media")]
        public IList<MediaModel> Medias { get { return _medias; } set { _medias = value; } }

        [JsonPropertyName("rooms")]
        public IList<RoomModel> Rooms { get { return _rooms; } set { _rooms = value; } }

        [JsonPropertyName("users")]
        public IList<UserModel> Users { get { return _users; } set { _users = value; } }
    }
}
