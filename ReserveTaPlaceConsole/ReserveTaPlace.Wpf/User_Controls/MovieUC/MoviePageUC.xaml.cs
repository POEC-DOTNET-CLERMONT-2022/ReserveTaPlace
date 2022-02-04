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

namespace ReserveTaPlace.Wpf.User_Controls.MovieUC
{
    /// <summary>
    /// Interaction logic for MoviePageUC.xaml
    /// </summary>
    public partial class MoviePageUC : UserControl
    {
        private readonly IMapper _mapper;
        private ListMovies _listMovie;
        public PaginatedList<MovieModel> PaginatedMovies;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;
        private int _pageIndex;
        private int _itemsPerPage;

        public MoviePageUC()
        {
            InitializeComponent();
            _listMovie = new ListMovies();
            _mapper = ((App)Application.Current).Mapper;
            DataContext = _listMovie;
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
            _pageIndex = 1;
            _itemsPerPage = 5;
            PaginatedMovies = new PaginatedList<MovieModel>();
        }

        private void ShowAddMovie_Click(object sender, RoutedEventArgs e)
        {
            SPSearchMovie.Visibility = Visibility.Collapsed;
            AddMovieUC.Visibility = Visibility.Visible;
            MoviesListUC.Visibility = Visibility.Collapsed;
        }

        private async void ShowListMovies(object sender, RoutedEventArgs e)
        {
            try
            {
                AddMovieUC.Visibility = Visibility.Collapsed;
                Gprogress.Visibility = Visibility.Visible;
                await Task.Delay(500);
                await LoadMovies();
            }
            finally
            {
                SPSearchMovie.Visibility = Visibility.Visible;
                Gprogress.Visibility = Visibility.Collapsed;
                MoviesListUC.Visibility = Visibility.Visible;
                WPSearchMovie.Visibility = Visibility.Visible;
                //MoviesListUC.Movies = _listMovie.Movies;
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
            _pageIndex++;
            await LoadMovies();
        }

        private async void pagerUC_GoPreviousPage(object sender, EventArgs e)
        {
            _pageIndex--;
            await LoadMovies();
        }
    }
}
