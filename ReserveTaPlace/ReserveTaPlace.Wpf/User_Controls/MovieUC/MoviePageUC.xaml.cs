using ReserveTaPlace.DTOS;
using ReserveTaPlace.Logic.DataManager;
using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using ReserveTaPlace.Models.WPFModels.StateManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for MoviePageUC.xaml
    /// </summary>
    public partial class MoviePageUC : UserControl
    {
        public ListMovies ListMovie;
        private SessionViewModel _sessionViewModel;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private readonly IDataManager<TheaterModel, TheaterDto> _theaterDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;
        private int _pageIndex;
        private int _itemsPerPage;

        public MoviePageUC()
        {
            InitializeComponent();
            ListMovie = new ListMovies();
            _sessionViewModel = new SessionViewModel();
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
            _pageIndex = 1;
            _itemsPerPage = 8;
            ListMovie.StateManager = new MoviePageStateManager(MoviePageState.MoviesListView);
            _theaterDataManager = ((App)Application.Current).TheaterDataManager;
            DataContext = ListMovie;


        }
        private void ShowAddMovie_Click(object sender, RoutedEventArgs e)
        {
            //PB LAstminute
            ListMovie.StateManager.Set(MoviePageState.AddMovieView);
            SPAddmovie.Visibility = Visibility.Visible;
            AddMovieUC.Visibility = Visibility.Visible;
            if (UCPutOnScreen.SessionViewModel != null)
            {
                UCPutOnScreen.SessionViewModel.SelectedMovie = null;
            }
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
                MoviesListUC.Visibility = Visibility.Visible;
                WPSearchMovie.Visibility = Visibility.Visible;
            }
            //TODO :Binding ? 

        }
        public async Task LoadMovies()
        {
            ListMovie.PaginatedMovies = await _movieDataManager.GetAllPaginated(_pageIndex, _itemsPerPage);
            ListMovie.Movies = new ObservableCollection<MovieModel>(ListMovie.PaginatedMovies.Data);
            pagerUC.PaginatedList = ListMovie.PaginatedMovies;
        }

        private async void BTNFindMovie_Click(object sender, RoutedEventArgs e)
        {
            TBUnfound.Visibility = Visibility.Collapsed;
            if (String.IsNullOrEmpty(TBMovieYear.Text))
            {

            }
            else
            {
                var movieFound = await _movieDataManager.GetMovieByNameAndYear(TBMovieName.Text, TBMovieYear.Text);
                var movies = new List<MovieModel>();
                if (movieFound == null)
                {
                    TBUnfound.Visibility = Visibility.Visible;
                }
                if (movieFound != null)
                {
                    movies.Add(movieFound);
                    ListMovie.Movies = new ObservableCollection<MovieModel>(movies);
                    MoviesListUC.Movies = ListMovie.Movies;
                }
            }

        }

        private async void pagerUC_GoNextPage(object sender, EventArgs e)
        {
            ListMovie.StateManager.Set(MoviePageState.MoviesListView);
            _pageIndex++;
            await LoadMovies();
        }

        private async void pagerUC_GoPreviousPage(object sender, EventArgs e)
        {
            ListMovie.StateManager.Set(MoviePageState.MoviesListView);
            _pageIndex--;
            await LoadMovies();
        }

        private void MoviesListUC_SelectionChanged(object sender, EventArgs e)
        {
            if (MoviesListUC.LBMovies.SelectedItem!=null)
            {
                ListMovie.CurrentMovie = MoviesListUC.LBMovies.SelectedItem as MovieModel;
                _sessionViewModel.SelectedMovie = ListMovie.CurrentMovie;
                UCPutOnScreen.SessionViewModel = _sessionViewModel;
                ListMovie.StateManager.Set(MoviePageState.PutOnScreenView);

            }
            if (MoviesListUC.LBMovies.SelectedItem == null)
            {
                ListMovie.StateManager.Set(MoviePageState.MoviesListView);

            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AddMovieUC.Visibility = Visibility.Collapsed;
                Gprogress.Visibility = Visibility.Visible;
                await LoadMovies();
                await LoadTheaters();
            }
            finally
            {
                Gprogress.Visibility = Visibility.Collapsed;

            }

        }

        private async Task LoadTheaters()
        {
            var theaters = await _theaterDataManager.GetAll();
            _sessionViewModel.Theaters = new ObservableCollection<TheaterModel>(theaters);
        }

        private void AddMovieUC_GoPreviousPage(object sender, EventArgs e)
        {
            ListMovie.StateManager.Set(MoviePageState.MoviesListView);
            SPAddmovie.Visibility = Visibility.Collapsed;
            AddMovieUC.Visibility = Visibility.Collapsed;
        }

        private async void BTNReload_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex = 1;
            await LoadMovies();
            MoviesListUC.Movies = ListMovie.Movies;
        }
    }
}
