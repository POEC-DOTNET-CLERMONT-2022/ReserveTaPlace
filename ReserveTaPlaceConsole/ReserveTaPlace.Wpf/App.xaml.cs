using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.MovieDataBaseService;
using ReserveTaPlace.Wpf.User_Controls;
using ReserveTaPlace.Wpf.User_Controls.MovieUC;
using ReserveTaPlace.Wpf.User_Controls.TheaterUC;
using ReserveTaPlace.Wpf.Utils;
using System;
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
        public IGenericLogic<UserModel> UserLogic;
        public IMovieLogic MovieLogic;

        public IMapper Mapper;
        public IMovieProvider MovieProvider;
        private const string SERVER_URL = "https://localhost:7091";

        public HttpClient HttpClient { get; }
        public IDataManager<UserModel, UserDto> UserDataManager { get; }
        public IDataManager<MovieModel, MovieDto> MovieDataManager { get; }
        public IDataManager<MovieModel, MovieDto> MovieProviderDataManager { get; }
        public IDataManager<TheaterModel, TheaterDto> TheaterDataManager { get; }
        public IDataManager<CalendarModel, CalendarDto> CalendarDataManager { get; }
        public IDataManager<SessionModel, SessionDto> SessionDataManager { get; }
        public IDataManager<RoomModel, RoomDto> RoomDataManager { get; }
        public IDataManager<FormatModel, FormatDto> FormatDataManager { get; }
        public IDataManager<RoleModel, RoleDto> RoleDataManager { get; }


        public INavigator Navigator { get; }

        public App()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(config);

            UserLogic = new GenericLogic<UserModel>();
            MovieLogic = new MovieLogic();

            MovieProvider = new MovieProvider();
            HttpClient = new HttpClient();
            UserDataManager = new UserDataManager(HttpClient, Mapper, SERVER_URL);
            MovieDataManager= new MovieDataManager(HttpClient, Mapper,SERVER_URL);
            TheaterDataManager = new TheaterDataManager(HttpClient, Mapper, SERVER_URL);
            MovieProviderDataManager = new IMDBDataManager(HttpClient, Mapper, SERVER_URL);
            CalendarDataManager = new CalendarDataManager(HttpClient, Mapper, SERVER_URL);
            SessionDataManager = new SessionDataManager(HttpClient, Mapper, SERVER_URL);
            RoomDataManager = new RoomDataManager(HttpClient, Mapper, SERVER_URL);
            FormatDataManager = new FormatDataManager(HttpClient, Mapper, SERVER_URL);
            RoleDataManager = new RoleDataManager(HttpClient, Mapper, SERVER_URL); 
            Navigator = new Navigator();

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Navigator.RegisterView(new HomePage());
            Navigator.RegisterView(new LoginPageUC());
            Navigator.RegisterView(new MoviePageUC());
            Navigator.RegisterView(new UserPageUC());
            Navigator.RegisterView(new TheaterPageUC());
        }
    }
}
