using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic;
using ReserveTaPlace.Logic.DataManager;
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
        private IMovieLogic _movieLogic;
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        private IMovieProvider _movieProvider;
        private readonly IDataManager<Movie, MovieDto> _movieDataManager;
        private IDataManager<Movie, MovieDto> _imdbDataManager;


        public MovieWindow()
        {
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            _movieLogic = ((App)Application.Current).MovieLogic;
            InitializeComponent();
            DataContext = _listMovie;
            _movieProvider = ((App)Application.Current).MoviProvider;
            _movieDataManager = ((App)Application.Current).MovieDataManager;

        }
        public async void LoadMovies()
        {
            var movies = await _movieDataManager.GetAll();
            var moviesModel = _mapper.Map<IEnumerable<Movie>>(movies);
            _listMovie.Movies = new ObservableCollection<Movie>(moviesModel);
        }

        private async void Button_AddMovie(object sender, RoutedEventArgs e)
        {
            var movieName = TBMovieToAddName.Text;
            var movieYear = TBMovieToAddYear.Text;
            var imdbMngr = new ImdbManager(movieName, movieYear);
            _imdbDataManager = imdbMngr.MovieProviderDataManager;
            //TODO
            //var test =await _imdbDataManager.GetMovie();
            
            var moviesDto = await _movieProvider.GetMovie(movieName, movieYear);
            List<MovieDto> movies = await _movieProvider.GetMovie(movieName, movieYear);
            if (moviesDto.Count>0)
            {
                var moviesModel = _mapper.Map<List<Movie>>(moviesDto);
                _listMovie.Movies.Add(moviesModel[0]);
                await _movieDataManager.Add(moviesModel[0]);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMovies();
        }
    }
}
