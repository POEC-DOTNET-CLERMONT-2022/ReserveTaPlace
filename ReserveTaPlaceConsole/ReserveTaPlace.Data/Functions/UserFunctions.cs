using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class UserFunctions : IUser
    {
        private IEnumerable<UserEntity> _users;
        private string _connectionString;
        public UserFunctions(string connectionString)
        {
            _connectionString = connectionString;
            _users = new List<UserEntity>();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            using (var context = new ReserveTaPlaceContext(_connectionString))
            {
                _users = await context.Users.ToListAsync();
            }
            return _users;
        }
    }
}
