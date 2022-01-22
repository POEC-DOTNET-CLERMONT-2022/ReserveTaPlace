using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.Logic.DataManager
{
    public class IMDBDataManager : ApiDataManager<Movie, MovieDto>
    {
        public IMDBDataManager(HttpClient client, IMapper mapper, string serverUrl, string resourceUrl)
            : base(client, mapper, serverUrl, resourceUrl)
        {
        }

        public new async Task<IEnumerable<Movie>> GetAll()
        {
            return await base.GetAll();
        }

        public new async Task Add(Movie model)
        {

        }
    }
}
