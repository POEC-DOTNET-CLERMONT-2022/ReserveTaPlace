﻿using AutoMapper;
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
        private SessionViewModel _sessionViewModel;
        public PaginatedList<MovieModel> PaginatedMovies;
        private readonly IDataManager<MovieModel, MovieDto> _movieDataManager;
        private readonly IDataManager<TheaterModel, TheaterDto> _theaterDataManager;
        private IDataManager<MovieModel, MovieDto> _movieProviderDataManager;
        private int _pageIndex;
        private int _itemsPerPage;

        public MoviePageUC()
        {
            InitializeComponent();
            _listMovie = new ListMovies();
            _sessionViewModel = new SessionViewModel();
            _movieDataManager = ((App)Application.Current).MovieDataManager;
            _movieProviderDataManager = ((App)Application.Current).MovieProviderDataManager;
            _pageIndex = 1;
            _itemsPerPage = 8;
            PaginatedMovies = new PaginatedList<MovieModel>();
            _listMovie.StateManager = new MoviePageStateManager(MoviePageState.MoviesListView);
            _theaterDataManager = ((App)Application.Current).TheaterDataManager;
            DataContext = _listMovie;
            //DataContext = new { _listMovie, _sessionViewModel };

        }
        private void ShowAddMovie_Click(object sender, RoutedEventArgs e)
        {
            _listMovie.StateManager.Set(MoviePageState.AddMovieView);
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
            _listMovie.StateManager.Set(MoviePageState.MoviesListView);
            _pageIndex++;
            await LoadMovies();
        }

        private async void pagerUC_GoPreviousPage(object sender, EventArgs e)
        {
            _listMovie.StateManager.Set(MoviePageState.MoviesListView);
            _pageIndex--;
            await LoadMovies();
        }

        private void MoviesListUC_SelectionChanged(object sender, EventArgs e)
        {
            if (MoviesListUC.LBMovies.SelectedItem!=null)
            {
                _listMovie.CurrentMovie = MoviesListUC.LBMovies.SelectedItem as MovieModel;
                _sessionViewModel.SelectedMovie = _listMovie.CurrentMovie;
                UCPutOnScreen.SessionViewModel = _sessionViewModel;
                _listMovie.StateManager.Set(MoviePageState.PutOnScreenView);

            }
            if (MoviesListUC.LBMovies.SelectedItem == null)
            {
                _listMovie.StateManager.Set(MoviePageState.MoviesListView);

            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMovies();
            await LoadTheaters();
        }

        private async Task LoadTheaters()
        {
            var theaters = await _theaterDataManager.GetAll();
            _sessionViewModel.Theaters = new ObservableCollection<TheaterModel>(theaters);
        }

        private void AddMovieUC_GoPreviousPage(object sender, EventArgs e)
        {
            _listMovie.StateManager.Set(MoviePageState.MoviesListView);
        }
    }
}
