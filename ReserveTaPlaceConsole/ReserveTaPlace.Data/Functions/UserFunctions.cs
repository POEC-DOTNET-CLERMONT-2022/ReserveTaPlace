﻿using Microsoft.EntityFrameworkCore;
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
        private DbContext _dbContext;
        private IEnumerable<UserEntity> _users;
        public UserFunctions(DbContext context)
        {
            _dbContext = context;
            _users = new List<UserEntity>();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {

                _users = await _dbContext.Set<UserEntity>().ToListAsync();

            return _users;
        }
    }
}