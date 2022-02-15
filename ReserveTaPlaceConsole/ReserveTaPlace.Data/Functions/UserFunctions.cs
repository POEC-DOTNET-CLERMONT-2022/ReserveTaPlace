using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Data.Utils;
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
        public async Task<PaginatedList<UserEntity>> GetAllPaginated(int pageIndex, int pageSize)
        {
            return await PaginatedList<UserEntity>.CreateAsync(_dbContext.Set<UserEntity>().Include(u=>u.Roles), pageIndex, pageSize);
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {

                _users = await _dbContext.Set<UserEntity>().ToListAsync();

            return _users;
        }
        public async Task<bool> Add(UserEntity user)
        {
            var roleId = user.Roles.First().Id;
            user.Roles.Clear();
            var role = await _dbContext.Set<RoleEntity>().FirstOrDefaultAsync(r => r.Id == roleId);
            user.Roles.Add(role);
            await _dbContext.Set<UserEntity>().AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
