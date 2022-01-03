using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlaceConsole.RTPManager
{
    public class UserManager
    {
        private readonly List<User> _users;

        private readonly UserLogic  _userLogic;
        public UserManager(List<User> users)
        {
            _users = users;
        }

        internal void SaveUsers(List<User> userList)
        {
            _userLogic.SaveUsers(userList);
        }
    }
}
