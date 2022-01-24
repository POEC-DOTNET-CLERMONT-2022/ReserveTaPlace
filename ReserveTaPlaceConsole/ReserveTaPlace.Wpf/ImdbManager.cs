using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Wpf
{
    public class ImdbManager
    {
        private const string SERVER_URL = "https://localhost:7091/api/Movie/";
        public HttpClient HttpClient { get; }
        public IMapper Mapper;
        public IDataManager<Movie, MovieDto> MovieProviderDataManager { get; }
        public ImdbManager(string title,string year)
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ImdbManager)));
            Mapper = new Mapper(config);
            HttpClient = new HttpClient();
            
            string ressource = $"?s={title}&r=json&type=movie&y={year}&page=1";
            MovieProviderDataManager = new IMDBDataManager(HttpClient, Mapper, SERVER_URL, ressource);

        }

    }
}
