using AutoMapper;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System.Collections.Generic;
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
        public MovieLogic MovieLogic;
        public IMapper Mapper;
        public App()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(config);
            UserLogic = new GenericLogic<User>();
            MovieLogic = new MovieLogic();
        }
    }
}
