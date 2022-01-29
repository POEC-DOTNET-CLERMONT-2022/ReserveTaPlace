using ReserveTaPlace.Models.CModels;

namespace ReserveTaPlace.Persistance.Interfaces
{
    public interface IUser
    {
        string GetUser(string login, string password);
        void SaveUsers(List<User> userList);
        void CreateUser(string login, string password, string confirmedPassword);
        void UpdatePassword(string password, string confirmedPassword);
        void UpdateUser(string login);
        Task<List<User>> GetUsers();
    }
}
