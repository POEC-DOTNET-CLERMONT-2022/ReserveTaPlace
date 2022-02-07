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
    public class SessionFunctions : ISession
    {
        private DbContext _dbContext;
        public SessionFunctions(DbContext DbContext)
        {
            _dbContext= DbContext;
        }
        public async Task<bool> AddSession(SessionEntity sessionEntity)
        {
            _dbContext.Set<SessionEntity>().Add(sessionEntity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
