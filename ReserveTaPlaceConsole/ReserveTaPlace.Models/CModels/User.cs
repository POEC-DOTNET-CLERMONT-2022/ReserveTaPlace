using Newtonsoft.Json;
using System;

namespace ReserveTaPlace.Models.CModels
{
    public class User
    {
        private readonly Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private UserRoles _userRoles;

        public User(string firstName, string lastName, string email, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _userRoles = UserRoles.Client;
        }
        public User(string firstName, string lastName, string email, string password, UserRoles userRoles) : this(firstName, lastName, email, password)
        {
            _userRoles = userRoles;
        }
        [JsonConstructor]
        public User(Guid id, string firstName, string lastName, string email, string password, UserRoles userRoles)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _userRoles = UserRoles.Client;

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
        [JsonProperty(PropertyName = "UserRoles")]

        public UserRoles UserRoles
        {
            get { return _userRoles; }
            set { _userRoles = value; }
        }
    }

}
