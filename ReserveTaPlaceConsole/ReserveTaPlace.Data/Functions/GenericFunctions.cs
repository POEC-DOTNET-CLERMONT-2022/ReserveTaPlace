using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class GenericFunctions<T> : IGenericRepo<T> where T : GenericEntity 
    {
        private IEnumerable<T> _listEntities;
        private string _connectionString;
        public GenericFunctions(string connectionString)
        {
            _connectionString = connectionString;
            _listEntities = new List<T>();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            int result = 0;
            using (var context = new ReserveTaPlaceContext(_connectionString))
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(u=>u.Id == id);
                context.Set<T>().Remove(entity);
                result = await context.SaveChangesAsync();
            };
            return result==1;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = new ReserveTaPlaceContext(_connectionString))
            {
                var test = context.Set<T>();
                _listEntities = await context.Set<T>().ToListAsync();
            }
            return _listEntities;
        }
    }
}
