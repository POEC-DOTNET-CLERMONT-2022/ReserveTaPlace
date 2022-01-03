using ReserveTaPlace.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Persistance.Functions
{
    internal class UserFunctions : IUser
    {
        public void CreateUser(string login, string password, string confirmedPassword)
        {
            throw new NotImplementedException();
        }

        public void GetUser(string login, string password)
        {

        }

        public void UpdatePassword(string password, string confirmedPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(string login)
        {
            throw new NotImplementedException();
        }
    }
}
