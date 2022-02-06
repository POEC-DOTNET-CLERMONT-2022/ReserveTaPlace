using AutoMapper;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Models.WPFModels.StateManager;
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

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for MoviePageUC.xaml
    /// </summary>
    public partial class MoviePageUC : UserControl
    {
        private ListMovies _listMovie;
        public PaginatedList<MovieModel> PaginatedMovies;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;
        private int _pageIndex;
        private int _itemsPerPage;

        public MoviePageUC()
        {
            InitializeComponent();
            //DataContext = new { _listMovie = _listMovie, StateManager = StateManager };
            _listMovie = new ListMovies();
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
            _pageIndex = 1;
            _itemsPerPage = 8;
            PaginatedMovies = new PaginatedList<MovieModel>();
            _listMovie.StateManager = new MoviePageStateManager(MoviePageState.MoviesListView);
            DataContext = _listMovie;
            AddMovieUC.Visibility = Visibility.Collapsed;
        }
        private void ShowAddMovie_Click(object sender, RoutedEventArgs e)
        {
            _listMovie.StateManager.Set(MoviePageState.AddMovieView);
            AddMovieUC.Visibility= Visibility.Visible;
        }

        private async void ShowListMovies(object sender, RoutedEventArgs e)
        {
            try
            {
                AddMovieUC.Visibility = Visibility.Collapsed;
                Gprogress.Visibility = Visibility.Visible;
                await Task.Delay(200);
                await LoadMovies();
            }
            finally
            {
                SPSearchMovie.Visibility = Visibility.Visible;
                Gprogress.Visibility = Visibility.Collapsed;
                MoviesListUC.Visibility = Visibility.Visible;
                WPSearchMovie.Visibility = Visibility.Visible;
            }

        }
        public async Task LoadMovies()
        {
            PaginatedMovies = await _movieDataManager.GetAllPaginated(_pageIndex, _itemsPerPage);
            _listMovie.Movies = new ObservableCollection<MovieModel>(PaginatedMovies.Data);
            pagerUC.PaginatedList = PaginatedMovies;
        }

        private async void BTNFindMovie_Click(object sender, RoutedEventArgs e)
        {
            TBUnfound.Visibility = Visibility.Collapsed;
            var movieFound = await _movieDataManager.GetMovieByNameAndYear(TBMovieName.Text, TBMovieYear.Text);
            var ListMovie = new List<MovieModel>();
            if (movieFound==null)
            {
                TBUnfound.Visibility = Visibility.Visible;
            }
            if (movieFound!=null)
            {
                ListMovie.Add(movieFound);
                _listMovie.Movies = new ObservableCollection<MovieModel>(ListMovie);
                MoviesListUC.Movies = _listMovie.Movies;
            }

        }

        private async void pagerUC_GoNextPage(object sender, EventArgs e)
        {
            SPMovieDetails.Visibility = Visibility.Hidden;
            _pageIndex++;
            await LoadMovies();
        }

        private async void pagerUC_GoPreviousPage(object sender, EventArgs e)
        {
            SPMovieDetails.Visibility = Visibility.Hidden;
            _pageIndex--;
            await LoadMovies();
        }

        private void MoviesListUC_SelectionChanged(object sender, EventArgs e)
        {
            _listMovie.CurrentMovie=MoviesListUC.LBMovies.SelectedItem as MovieModel;
            _listMovie.StateManager.Set(MoviePageState.PutOnScreenView );
            SPMovieDetails.Visibility = Visibility.Visible;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMovies();
        }

        private void AddMovieUC_GoPreviousPage(object sender, EventArgs e)
        {
            AddMovieUC.Visibility = Visibility.Collapsed;
            pagerUC.Visibility = Visibility.Visible;
            _listMovie.StateManager.Set(MoviePageState.MoviesListView);
        }
    }
}
