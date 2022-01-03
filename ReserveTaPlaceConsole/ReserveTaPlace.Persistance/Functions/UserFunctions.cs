using Newtonsoft.Json;
using ReserveTaPlace.Models;
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

        public string GetUser(string login, string password)
        {
            var jsonUsers = File.ReadAllText(@"userList.txt");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            var user = users.FirstOrDefault(u=>u.Email == login);
            if (user == null)
            {
                return "user non trouvé";
            }
            if(user.Password != password)
            {
                return $"Mot de passe incorrect {password}";
            }
            return "success";
        }

        public void UpdatePassword(string password, string confirmedPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(string login)
        {
            throw new NotImplementedException();
        }
        public void SaveUsers(List<User> userList)
        {
            using (FileStream fs = File.Create(@"userList.txt"))
            {

                fs.Close();
            }
            var jsonString = JsonConvert.SerializeObject(userList);
            File.WriteAllText(@"userList.txt", jsonString);
        }
    }
}
