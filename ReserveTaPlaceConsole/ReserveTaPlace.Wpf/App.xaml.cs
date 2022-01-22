using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.MovieDataBaseService;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IGenericLogic<User> UserLogic;
        public IMovieLogic MovieLogic;

        public IMapper Mapper;
        public IMovieProvider MoviProvider;
        private const string SERVER_URL = "https://localhost:7091";
        public static string Title { get; set; }
        public static string Year { get; set; }

        public HttpClient HttpClient { get; }
        public IDataManager<Movie, MovieDto> MovieProviderDataManager { get; }
        public IDataManager<User, UserDto> UserDataManager { get; }
        public IDataManager<Movie, MovieDto> MovieDataManager { get; }

        public App()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(config);

            UserLogic = new GenericLogic<User>();
            MovieLogic = new MovieLogic();

            MoviProvider = new MovieProvider();
            HttpClient = new HttpClient();
            UserDataManager = new UserDataManager(HttpClient, Mapper, SERVER_URL);
            MovieDataManager= new MovieDataManager(HttpClient, Mapper,SERVER_URL);
            MovieProviderDataManager = new IMDBDataManager(HttpClient, Mapper, SERVER_URL, $"?s={Title}&r=json&type=movie&y={Year}&page=1");
        }
    }
}
