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
        private List<RoleModel> _roles;
        private List<TheaterModel> _theaters;

        public UserModel(string firstName, string lastName, string email, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _roles = new List<RoleModel>();
            _theaters = new List<TheaterModel>();
        }
        [JsonConstructor]
        public UserModel(Guid id, string firstName, string lastName, string email, string password, List<RoleModel> roles, List<TheaterModel> theaters)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _roles = roles;
            _theaters = theaters;

        }

        public Guid Id { get { return _id; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string Email { get { return _email; } }
        public string Password { get { return _password; } }
        public List<RoleModel> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        public List<TheaterModel> Theaters
        {
            get { return _theaters; }
            set { _theaters = value; }
        }

    }
}
