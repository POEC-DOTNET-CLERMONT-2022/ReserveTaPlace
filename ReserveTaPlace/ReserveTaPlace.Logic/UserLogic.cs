using ReserveTaPlace.Models.CModels;
using ReserveTaPlace.Persistance.Functions;
using ReserveTaPlace.Persistance.Interfaces;

namespace ReserveTaPlace.Logic
{
    public class UserLogic
    {
        private readonly IUser _user;
        public UserLogic()
        {
            _user = new UserFunctions();
        }
        public void SaveUsers(List<User> userList)
        {
            _user.SaveUsers(userList);
        }
        public string GetUser(string login, string password)
        {
            return _user.GetUser(login, password);
        }
        public void CreateUser(string login, string password, string confirmedPassword)
        {
            _user.CreateUser(login, password, confirmedPassword);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _user.GetUsers();
        }

        public void UpdatePassword(string password, string confirmedPassword)
        {
            _user.UpdatePassword(password, confirmedPassword);
        }
        public void UpdateUser(string login)
        {
            _user.UpdateUser(login);
        }
    }
}
