using AutoMapper;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using System.Collections.Generic;
using System.Windows;

namespace ReserveTaPlace.Wpf
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        private MovieLogic MovieLogic;
        private IEnumerable<Movie> MovieList;
        private readonly IMapper _mapper;
        public MovieWindow()
        {
            _mapper = ((App)Application.Current).Mapper;
            MovieList = new List<Movie>();
            MovieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
            LoadMovies();
            DataContext = MovieList;
        }
        public async void LoadMovies()
        {
            var movies = await MovieLogic.GetAll();
            MovieList = _mapper.Map<IEnumerable<Movie>>(movies);
            LBMovies.DataContext = MovieList;
        }
    }
}
