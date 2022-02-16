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
    public class FormatFunctions : IFormat
    {
        private IEnumerable<FormatEntity> _formats;
        private DbContext _dbContext;

        public FormatFunctions(DbContext context)
        {
            _dbContext = context;
            _formats = new List<FormatEntity>();
        }
        public async Task<IEnumerable<FormatEntity>> GetAll()
        {
            _formats = await _dbContext.Set<FormatEntity>().ToListAsync();
            return _formats;
        }
    }
}
