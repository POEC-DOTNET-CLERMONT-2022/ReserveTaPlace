using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;

namespace ReserveTaPlaceConsole.RTPManager
{
    public class UserManager
    {
        private readonly List<User> _users;

        private readonly UserLogic _userLogic;
        public UserManager(List<User> users)
        {
            _users = new List<User>();
            _userLogic = new UserLogic();
        }

        internal void SaveUsers(List<User> userList)
        {
            _userLogic.SaveUsers(userList);
        }
    }
}
