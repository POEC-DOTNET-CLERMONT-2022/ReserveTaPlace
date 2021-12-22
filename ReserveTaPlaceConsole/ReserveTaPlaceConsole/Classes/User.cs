using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole.Classes
{
    internal class User
    {
        private readonly Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        public User(string firstName, string lastName, string email, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            
        }
        public Guid Id { get { return _id;} }
        public string FirstName { get { return _firstName;} }
        public string LastName { get { return _lastName;} }
        public string Email { get { return _email;}}
        public string Password { get { return _password;} }
    }

}
