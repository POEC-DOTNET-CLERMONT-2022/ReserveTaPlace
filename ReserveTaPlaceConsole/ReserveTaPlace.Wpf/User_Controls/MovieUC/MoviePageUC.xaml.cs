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
            try
            {
                AddMovieUC.Visibility = Visibility.Collapsed;
                Gprogress.Visibility = Visibility.Visible;
                await Task.Delay(5000);
                await LoadMovies();


            }
            finally
            {
                Gprogress.Visibility = Visibility.Collapsed;
                MoviesListUC.Visibility = Visibility.Visible;
                MoviesListUC.Movies = _listMovie.Movies;


            }

        }
        public async Task LoadMovies()
        {
            var movies = await _movieDataManager.GetAllPaginated(1,5);
            _listMovie.Movies = new ObservableCollection<MovieModel>(movies.Data);
        }
    }
}
