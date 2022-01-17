using AutoMapper;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        private MovieLogic MovieLogic;
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        public MovieWindow()
        {
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            MovieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
            LoadMovies();
            DataContext = _listMovie;

        }
        public async void LoadMovies()
        {
            var movies = await MovieLogic.GetAll();
            var moviesModel = _mapper.Map<IEnumerable<Movie>>(movies);
            _listMovie.Movies = new ObservableCollection<Movie>(moviesModel);
        }
    }
}
