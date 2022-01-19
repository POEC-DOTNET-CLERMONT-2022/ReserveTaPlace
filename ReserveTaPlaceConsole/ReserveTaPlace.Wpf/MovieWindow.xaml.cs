using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.MovieDataBaseService;
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
        private IMovieProvider _movieProvider;
        public MovieWindow()
        {
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            MovieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
            LoadMovies();
            DataContext = _listMovie;
            _movieProvider = ((App)Application.Current).MoviProvider;

        }
        public async void LoadMovies()
        {
            var movies = await MovieLogic.GetAll();
            var moviesModel = _mapper.Map<IEnumerable<Movie>>(movies);
            _listMovie.Movies = new ObservableCollection<Movie>(moviesModel);
        }

        private async void Button_AddMovie(object sender, RoutedEventArgs e)
        {
            var movieName = TBMovieToAddName.Text;
            var movieYear = TBMovieToAddYear.Text;
            var movies = await _movieProvider.GetMovie(movieName, movieYear);
            _listMovie.Movies.Add(movies[0]);
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            await MovieLogic.Add(moviesDto[0]);
        }

    }
}
