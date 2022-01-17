using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class GenericFunctions<T> : IGenericRepo<T> where T : class
    {
        private IEnumerable<T> _listEntities;
        public GenericFunctions()
        {
            _listEntities = new List<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {

            using (var context = new ReserveTaPlaceContext())
            {
                _listEntities = await context.Set<T>().ToListAsync();
            }
            return _listEntities;
        }
    }
}
