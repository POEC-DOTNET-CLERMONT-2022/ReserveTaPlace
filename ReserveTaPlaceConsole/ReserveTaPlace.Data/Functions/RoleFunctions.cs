using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class RoleFunctions : IRole
    {
        private DbContext _dbContext;
        public RoleFunctions(DbContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<RoleEntity>> GetAll()
        {
            var roles = await _dbContext.Set<RoleEntity>().ToListAsync();
            return roles;
        }
    }
}
