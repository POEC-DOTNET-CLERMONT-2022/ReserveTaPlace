using ReserveTaPlace.Models;
using ReserveTaPlace.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic
{
    public class UserLogic
    {
        private readonly IUser _user;
        public void SaveUsers(List<User> userList)
        {
            _user.SaveUsers(userList);
        }
    }
}
