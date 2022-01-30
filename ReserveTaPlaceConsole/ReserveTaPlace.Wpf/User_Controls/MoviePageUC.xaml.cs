using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReserveTaPlace.Wpf.User_Controls
{
    /// <summary>
    /// Interaction logic for MoviePageUC.xaml
    /// </summary>
    public partial class MoviePageUC : UserControl
    {
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;

        public MoviePageUC()
        {
            InitializeComponent();
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            DataContext = _listMovie;
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
        }

        private void ShowAddMovie_Click(object sender, RoutedEventArgs e)
        {
            AddMovieUC.Visibility = Visibility.Visible;
            MoviesListUC.Visibility = Visibility.Collapsed;
        }

        private async void ShowListMovies(object sender, RoutedEventArgs e)
        {
            await LoadMovies();
            MoviesListUC.Visibility = Visibility.Visible;
            MoviesListUC.Movies = _listMovie.Movies;
            AddMovieUC.Visibility = Visibility.Collapsed;
        }
        public async Task LoadMovies()
        {
            var movies = await _movieDataManager.GetAll();
            var moviesModel = _mapper.Map<IEnumerable<MovieModel>>(movies);
            _listMovie.Movies = new ObservableCollection<MovieModel>(moviesModel);
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMovies();
        }
    }
}
