using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Models;

namespace ReserveTaPlace.Logic.DataManager
{
    public class IMDBDataManager : ApiDataManager<MovieModel, MovieDto>
    {
        public IMDBDataManager(HttpClient client, IMapper mapper, string serverUrl)
            : base(client, mapper, serverUrl, "/api/movie/ImdbMovie")
        {
        }

        public new async Task<IEnumerable<MovieModel>> GetAll()
        {
            return await base.GetAll();
        }

        public new async Task Add(MovieModel model)
        {

        }
    }
}
