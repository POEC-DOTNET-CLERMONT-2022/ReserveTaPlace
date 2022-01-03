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
        public void GetUser(string login, string password)
        {

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
