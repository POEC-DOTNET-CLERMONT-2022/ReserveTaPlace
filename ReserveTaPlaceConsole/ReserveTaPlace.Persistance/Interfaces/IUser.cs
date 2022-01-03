using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Persistance.Interfaces
{
    public interface IUser
    {
        void GetUser(string login, string password);
        void CreateUser(string login, string password, string confirmedPassword);
        void UpdatePassword(string password, string confirmedPassword);
        void UpdateUser(string login);
        void SaveUsers(List<User> userList);
    }
}
