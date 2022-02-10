using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Models
{
    public class UserModel
    {
        private readonly Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private IList<RoleModel> _Roles;
        private IList<TheaterUserModel> _userTheaters;

        public UserModel(string firstName, string lastName, string email, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _Roles = new List<RoleModel>();
            _userTheaters = new List<TheaterUserModel>();
        }
        [JsonConstructor]
        public UserModel(Guid id, string firstName, string lastName, string email, string password, List<RoleModel> roles, List<TheaterUserModel> userTheaters)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _Roles = roles;
            _userTheaters = userTheaters;

        }

        [JsonProperty(PropertyName = "Id")]
        public Guid Id { get { return _id; } }
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get { return _firstName; } }
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get { return _lastName; } }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get { return _email; } }
        [JsonProperty(PropertyName = "Password")]
        public string Password { get { return _password; } }
        [JsonProperty(PropertyName = "Roles")]
        public IList<RoleModel> Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }

    }
}
